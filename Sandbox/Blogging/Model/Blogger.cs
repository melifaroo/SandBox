using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Blogging.Model
{
    [Table("bloggers")]
    public class Blogger
    {
        public int BloggerId { get; set; }
        public string NickName { get; set; }

    }
}
