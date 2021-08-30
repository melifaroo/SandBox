using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Blogging.Model
{
    [Table("blogs")]
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
}
