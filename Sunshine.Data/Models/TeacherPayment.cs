using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class TeacherPayment
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime RecievedTime { get; set; }

        public IList<StudentPayment> StudentPayments { get; set; } 

        public string? Description { get; set; }

        public TeacherPayment()
        {
            StudentPayments = new List<StudentPayment>();
        }
    }
}
