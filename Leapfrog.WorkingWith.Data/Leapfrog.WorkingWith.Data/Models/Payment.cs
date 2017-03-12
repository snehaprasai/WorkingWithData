using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.WorkingWith.Data.Models
{
    public class Payment
    {
        public string BillNum { get; set; }
        public Enrollment StudentId { get; set; }
        public int fees { get; set; }
        public int Paid { get; set; }
        public int Due { get; set; }
    }
}
