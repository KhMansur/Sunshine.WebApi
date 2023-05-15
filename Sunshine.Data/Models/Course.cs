using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int DurationMonth { get; set; }

        public string? Description { get; set; }

        public Speciality Speciality { get; set; }
    }
}
