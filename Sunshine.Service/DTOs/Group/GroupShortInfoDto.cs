using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class GroupShortInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Days { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string CourseName { get; set; }

        public string TeacherName { get; set; }

    }
}
