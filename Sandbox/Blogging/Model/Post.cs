using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsApp.Sandbox.Blogging.Model
{
    [Table("posts")]
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Blogger Blogger { get; set; }
        public Blog Blog { get; set; }
    }
}
