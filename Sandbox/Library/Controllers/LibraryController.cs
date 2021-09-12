using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Library.Model;
using SandBox.Sandbox.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandBox.Sandbox.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _service;
        private readonly ILibraryDataService _data;

        public LibraryController(ILibraryService service, ILibraryDataService data)
        {
            _service = service;
            _data = data;
        }

        // POST: Library/Seed
        [Route("seed")]
        [HttpPost]
        public IActionResult Seed()
        {
            try
            {
                _data.Seed();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("authors")]
        // GET: Authors
        public IActionResult Authors()
        {
            return Json(_data.Authors());
        }

        [HttpGet]
        [Route("readers")]
        // GET: Readers
        public IActionResult Readers()
        {
            return Json(_data.Readers());
        }

        [HttpGet]
        [Route("books")]
        // GET: Books { Id Title Author.FullName TotalAmount }
        public IActionResult Books()
        {
            return Json(_service.BookList());
        }


        [HttpGet]
        [Route("storage")]
        // GET: Books { Id Title Author.FullName TotalAmount }
        public IActionResult Storage()
        {
            return Json(_service.Storage());
        }

        [HttpGet]
        [Route("register")]
        // GET: Books { Id Title Author.FullName TotalAmount }
        public IActionResult Register()
        {
            return Json(_service.Register());
        }

        [HttpPost]
        [Route("borrow")]
        public string Borrow(Borrowing borrowing)
        {
            var result = _service.CheckAvailable(borrowing.Book);
            if (result)
            {
                if (!_data.HasReader(borrowing.Reader))
                {
                    _data.AddReader(borrowing.Reader);
                }
                _data.AddBorrowing(borrowing);
                        //new Borrowing
                        //{
                        //    Book = borrowing.Book,
                        //    Reader = borrowing.Book,
                        //    BorrowingDate = DateTime.Today,
                        //    Term = _service.DefaultBorrowingTerm
                        //}
                return "succesfully borrowed";
            }
            else
            {
                return "not borrowed";
            }
        }

    }
}
