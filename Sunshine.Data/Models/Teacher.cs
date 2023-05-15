using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public int ExperienceYears { get; set; }

        public string PhoneNumber { get; set; }

        public string AdditionalPhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public double SalaryPercentage { get; set; }

        public IList<Speciality> Speciality { get; set; }

        public IList<Group> Groups { get; set; }

        public IList<TeacherPayment> TeacherPayments { get; set; }

        public Teacher()
        {
            Speciality = new List<Speciality>();
            Groups = new List<Group>();
        }
    }
}
