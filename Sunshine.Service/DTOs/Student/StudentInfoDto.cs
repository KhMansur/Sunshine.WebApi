using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class StudentInfoDto
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string? AdditionalPhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Gender { get; set; }

        public bool IsPrivileged { get; set; }

        public string? PrivilegeDescription { get; set; }

        public DateTime CreatedTime { get; set; }

        public IList<GroupShortInfoDto> GroupsShortInfo { get; set; }

        public IList<StudentPaymentShortInfoDto> PaymentsShortInfo { get; set; }
    }
}
