using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Library.Model
{

    [Table("readers")]
    public class Reader
    {
        public int ReaderId { get; set; }
        public string FullName { get; set; }
    }
}
