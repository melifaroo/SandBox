using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Library.Model
{
    [Table("books")]
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public Author Author { get; set; }
        [Required]
        public int TotalAmount { get; set; }
        
    }
}
