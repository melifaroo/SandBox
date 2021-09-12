using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sandbox.Blogging.Model;

namespace Sandbox.Blogging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class BlogsController : Controller
    {
        private readonly SandBoxContext _context;

        public BlogsController(SandBoxContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return Json(await _context.Blogs.ToListAsync());
        }

        [Route("{id}")]
        // GET: Blogs/5
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.SingleOrDefaultAsync(b => b.BlogId == id);

            if (blog == null)
            {
                return NotFound();
            }
            return Json(blog);
        }

        [Route("{id}/posts")]
        // GET: Blogs/5/posts
        public async Task<IActionResult> GetBlogPosts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogPosts = await _context.Posts
                    .Join(_context.Bloggers, p => p.Blogger.BloggerId, b => b.BloggerId,
                        (p, b) => new { Post = p, Blogger = b })
                    .Join(_context.Blogs, p => p.Post.Blog.BlogId, b => b.BlogId,
                        (p, b) => new { PostId = p.Post.PostId, Title = p.Post.Title, Content = p.Post.Content, BloggerId = p.Blogger.BloggerId, Blogger = p.Blogger.NickName, BlogId = b.BlogId, Blog = b.Url })
                    .Where(p => p.BlogId == id)
                    .ToListAsync();
            return Json(blogPosts);
        }


        [Route("{id}/postsCount")]
        // GET: Blogs/5/postsCount
        public async Task<IActionResult> GetPostsCount(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }
            var count = await _context.Posts.Where(p => p.Blog.BlogId == id).CountAsync();
            return Json(count);
        }

        [Route("{id}/authorsCount")]
        // GET: Blogs/5/authorsCount
        public async Task<IActionResult> GetAuthorsCount(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }
            var count = await _context.Posts.Where(p => p.Blog.BlogId == id).GroupBy(p => p.Blogger.BloggerId).CountAsync();
            return Json(count);
        }

        // POST: Blogs/Seed
        [Route("seed")]
        [HttpPost]
        public async Task<IActionResult> Seed(int blogCount, int bloggerCount, int postCount)
        {
            try
            {
                var recordsCount = await _context.SeedBlogsData(blogCount, bloggerCount, postCount);
                return Ok(recordsCount);
            }
            catch (Exception) { 
                return BadRequest();            
            }
        }


        // POST: Blogs/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(int id, [Bind("BlogId, Url")] Blog blog)
        {
            if (id != blog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogId))
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
            return Json(blog);
        }

        // POST: Blogs/Create
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("BlogId,Url")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return Ok(blog.BlogId);
            }
            return null;
        }

        // POST: Blogs/Delete/5
        [Route("delete/{id}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(b => b.BlogId == id);

                var blogPosts = await _context.Posts.Where(p => p.Blog.BlogId == id).ToListAsync();
                _context.Posts.RemoveRange(blogPosts);

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
