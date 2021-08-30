using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Library.Model
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public Reader Reader { get; set;  }
        public Book Book { get; set; }
        public DateTime Date { get; set; }
        public int Term { get; set; }

    }
}
