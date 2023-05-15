using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class RegisterStudentDto
    {
        [Required(ErrorMessage = "Firstname Name is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Firstname Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string? AdditionalPhoneNumber { get; set; }

        public string Gender { get; set; }

        public bool IsPrivileged { get; set; }

        public string? PrivilegeDescription { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
