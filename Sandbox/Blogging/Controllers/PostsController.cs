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
    [Route("api/sandbox/blogging/[controller]")]
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
            return Json(await _context.Posts
                .Join(_context.Bloggers, p => p.Blogger.BloggerId, b => b.BloggerId,
                (p, b) => new { Post = p, Blogger = b })
                .Join(_context.Blogs, p => p.Post.Blog.BlogId, b => b.BlogId,
                (p, b) => new { PostId = p.Post.PostId, Title = p.Post.Title, Content = p.Post.Content, BloggerId = p.Blogger.BloggerId, Blogger = p.Blogger.NickName, BlogId = b.BlogId, Blog = b.Url })
                .ToListAsync()
                );
            //return Json(await _context.Posts.Include(p => p.Blogger).Include(p => p.Blog).ToListAsync()); //
        }

        [Route("{id}")]
        // GET: Posts/5
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            //var person = await _context.People
            //    .FirstOrDefaultAsync(m => m.PersonId == id);
            if (post == null)
            {
                return NotFound();
            }
            return Json(post);
        }

        [Route("{id}/blogger")]
        // GET: Posts/5/blogger
        public async Task<IActionResult> GetBlogger(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogger = await _context.Posts.FindAsync(id);
            //var person = await _context.People
            //    .FirstOrDefaultAsync(m => m.PersonId == id);
            if (blogger == null)
            {
                return NotFound();
            }
            return Json(blogger);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(int id, [Bind("PostId,Title, Content, Blogger, Blog")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            return Json(post);
        }

        // POST: Posts/Delete/5
        [Route("delete/{id}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
