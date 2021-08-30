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

            var blogger = await _context.Bloggers.SingleOrDefaultAsync(b => b.BloggerId == id);

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
            var count = await _context.Posts.Where(p => p.Blogger.BloggerId == id).GroupBy(p => p.Blog.BlogId).CountAsync();
            return Json(count);
        }

        // POST: Bloggers/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(int id, [Bind("BloggerId, NickName")] Blogger blogger)
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
            var blogger = await _context.Bloggers.SingleOrDefaultAsync(b => b.BloggerId == id);

                var bloggerPosts = await _context.Posts.Where(p => p.Blogger.BloggerId == id).ToListAsync();
                _context.Posts.RemoveRange(bloggerPosts);

            _context.Bloggers.Remove(blogger);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Route("{id}/blogs")]
        // GET: Bloggers/5/blogs
        public async Task<IActionResult> GetBloggerBlogs(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //await _context.Posts.Where(p => p.Blogger.BloggerId == id)
            return Json(await _context.Posts.Where(p => p.Blogger.BloggerId == id).Select(p => p.Blog).Distinct().ToListAsync());
        }

        [Route("{id}/posts")]
        // GET: Bloggers/5/posts
        public async Task<IActionResult> GetBloggerPosts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            return Json(await _context.Posts
                        .Join(_context.Bloggers, p => p.Blogger.BloggerId, b => b.BloggerId, 
                        (p, b) => new { Post = p,  Blogger = b })
                        .Join(_context.Blogs, p => p.Post.Blog.BlogId, b => b.BlogId,
                        (p, b) => new { PostId = p.Post.PostId, Title = p.Post.Title, Content = p.Post.Content, BloggerId = p.Blogger.BloggerId, Blogger = p.Blogger.NickName, BlogId = b.BlogId, Blog = b.Url })
                    .Where(p => p.BloggerId == id).ToListAsync());
        }


        private bool PersonExists(int id)
        {
            return _context.Bloggers.Any(e => e.BloggerId == id);
        }
    }
}
