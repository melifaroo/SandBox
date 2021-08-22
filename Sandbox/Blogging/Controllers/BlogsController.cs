using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WordsApp.Sandbox;
using WordsApp.Sandbox.Blogging.Model;

namespace WordsApp.Sandbox.Blogging.Controllers
{
    [ApiController]
    [Route("sandbox/blogging/[controller]")]
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
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            //var person = await _context.People
            //    .FirstOrDefaultAsync(m => m.PersonId == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Json(blog);
        }

        [Route("{id}/posts")]
        // GET: Bloggers/5/posts
        public async Task<IActionResult> GetBlogPosts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Json(await _context.Posts.Where(p => p.Blog.BlogId == id).Include(p => p.Blogger).Include(p => p.Blog).ToListAsync());
        }


        [Route("{id}/postsCount")]
        // GET: Blogs/5/postsCount
        public async Task<IActionResult> GetPostsCount(int? id)
        {
            if (id == null)
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
            if (id == null)
            {
                return NotFound();
            }
            var count = await _context.Posts.Where(p => p.Blog.BlogId == id).GroupBy(p => p.Blogger.BloggerId).CountAsync();
            return Json(count);
        }

        // POST: Blogs/Seed
        [Route("seed")]
        [HttpPost]
        public IActionResult Seed(int blogCount, int bloggerCount, int postCount)
        {
            _context.Database.EnsureCreated();
            _context.Posts.RemoveRange(_context.Posts);
            _context.Bloggers.RemoveRange(_context.Bloggers);
            _context.Blogs.RemoveRange(_context.Blogs);


            var blogFaker =
                new Faker<Blog>()
                .RuleFor(x => x.Url, f => f.Random.Word());
            var bloggerFaker =
                new Faker<Blogger>()
                .RuleFor(x => x.NickName, f => f.Name.FullName());
            var blogs = blogFaker.Generate(blogCount);
            var bloggers = bloggerFaker.Generate(bloggerCount);
            foreach (Blog blog in blogs)
            {
                var testBlog = _context.Blogs.FirstOrDefault(b => b.Url == blog.Url);
                if (testBlog == null)
                {
                    _context.Blogs.Add(blog);
                }
            }
            foreach (Blogger blogger in bloggers)
            {
                var testBlogger = _context.Bloggers.FirstOrDefault(b => b.NickName == blogger.NickName);
                if (testBlogger == null)
                {
                    _context.Bloggers.Add(blogger);
                }
            }

            _context.SaveChanges();

            int[] bloggerIds = new int[] { 0 };

            var postFaker =
                new Faker<Post>()
                .RuleFor(x => x.Title, f => f.Random.Word())
                .RuleFor(x => x.Content, f => f.Random.Words())
                .RuleFor(x => x.Blogger, f => f.Random.ArrayElement(_context.Bloggers.ToArray()))
                .RuleFor(x => x.Blog, f => f.Random.ArrayElement(_context.Blogs.ToArray()));
            var posts = postFaker.Generate(postCount);

            foreach (Post post in posts)
            {
                _context.Posts.Add(post);
            }

            _context.SaveChanges();

            return Ok();
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
