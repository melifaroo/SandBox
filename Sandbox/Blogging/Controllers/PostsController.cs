using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WordsApp.Sandbox.Blogging.Model;

namespace WordsApp.Sandbox.Blogging.Controllers
{
    [ApiController]
    [Route("sandbox/blogging/[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PostsController : Controller
    {
        private readonly SandBoxContext _context;
        public PostsController(SandBoxContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return Json(await _context.Posts.Include(p => p.Blogger).Include(p => p.Blog).ToListAsync()); //
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
