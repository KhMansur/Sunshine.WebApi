using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Attendence
    {
        public Guid Id { get; set; }

        public Student Student { get; set; }

        public Group Group { get; set; }

        public int PaidDays { get; set; }

        public IList<AttendencePerDay> AttendencePerDay { get; set; }

        public Attendence()
        {
            AttendencePerDay = new List<AttendencePerDay>();
        }
    }
}
