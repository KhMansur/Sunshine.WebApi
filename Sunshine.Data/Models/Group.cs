using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Group
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Days { get; set; }

        public int DurationMinutes { get; set; }
        
        public string StartTime { get; set; }

        public Teacher Teacher { get; set; }

        public string EndTime { get; set; }

        public IList<Student> Students { get; set; }

        public Course Course { get; set; }

        public IList<StudentPayment> StudentPayments { get; set; }

        public Group()
        {
            Course = new Course();
            Students = new List<Student>();
            StudentPayments= new List<StudentPayment>();
        }
    }
}
