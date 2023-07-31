using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class StudentPaymentAddDto
    {
        public int Amount { get; set; }

        public Guid StudentId { get; set; }

        public int PerDays { get; set; }

        public Guid GroupId { get; set; }

        public string? Description { get; set; }
    }
}
