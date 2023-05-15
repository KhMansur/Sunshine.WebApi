using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class GroupAddDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Days { get; set; }

        public int DurationMinutes { get; set; }

        public string StartTime { get; set; }

        public Guid TeacherId { get; set; }

        public string EndTime { get; set; }

        public Guid CourseId { get; set; }
    }
}
