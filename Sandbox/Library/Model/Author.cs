using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Library.Model
{
    [Table("authors")]
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
    }
}
