using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Library.Model
{
    [Table("borrowings")]
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public Reader Reader { get; set;  }
        public Book Book { get; set; }
        public DateTime BorrowingDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public int Term { get; set; }

        public bool Closed { get; set; } = false;

        

    }
}
