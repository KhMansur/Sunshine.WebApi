﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class StudentListDto
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Gender { get; set; }

        public bool IsPrivileged { get; set; }

    }
}
