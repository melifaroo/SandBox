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
    public class BloggersController : Controller
    {
        private readonly SandBoxContext _context;
        public BloggersController(SandBoxContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Bloggers
        public async Task<IActionResult> Index()
        {
            return Json(await _context.Bloggers.ToListAsync());
        }

        // POST: Bloggers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("BloggerId,NickName")] Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogger);
                await _context.SaveChangesAsync();
                return Ok(blogger.BloggerId);
            }
            return null;
        }

        [Route("{id}")]
        // GET: Bloggers/5
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogger = await _context.Bloggers.FindAsync(id);
            //var person = await _context.People
            //    .FirstOrDefaultAsync(m => m.PersonId == id);
            if (blogger == null)
            {
                return NotFound();
            }
            return Json(blogger);
        }

        [Route("{id}/postsCount")]
        // GET: Bloggers/5/postsCount
        public async Task<IActionResult> GetPostsCount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var count = await _context.Posts.Where(p => p.Blogger.BloggerId == id).CountAsync();
            return Json(count);
        }

        [Route("{id}/blogsCount")]
        // GET: Bloggers/5/blogsCount
        public async Task<IActionResult> GetBlogsCount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var query = from p in _context.Posts 
            //            where p.Author.PersonId == id
            //            group p by p.BlogId into g
            //            select new
            //            {
            //                count = g.Count()
            //            };
            var count = await _context.Posts.Where(p => p.Blogger.BloggerId == id).GroupBy(p => p.Blog.BlogId).CountAsync();
            return Json(count);
        }

        // POST: Bloggers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(int id, [Bind("BloggerId,NickName")] Blogger blogger)
        {
            if (id != blogger.BloggerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(blogger.BloggerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return Json(blogger);
        }

        // POST: Bloggers/Delete/5
        [Route("delete/{id}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Bloggers.FindAsync(id);
            _context.Bloggers.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Bloggers.Any(e => e.BloggerId == id);
        }
    }
}
