using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class AttendencePerDay
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Attendence Attendence { get; set; }
    }
}
