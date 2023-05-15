using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class TeacherAddDto
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public int ExperienceYears { get; set; }

        public string PhoneNumber { get; set; }

        public string AdditionalPhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public double SalaryPercentages { get; set; }
    }
}
