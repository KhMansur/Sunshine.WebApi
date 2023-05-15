using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class CourseAddDto
    {
        public string Name { get; set; }

        public int DurationMonth { get; set; }

        public string? Description { get; set; }

        public Guid SpecialityId { get; set; }
    }
}
