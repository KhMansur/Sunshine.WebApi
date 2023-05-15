using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs
{
    public class StudentPaymentShortInfoDto
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public DateTime RecievedTime { get; set; }

        public Guid GroupId { get; set; }

        public string GroupName { get; set; }

        public bool isCalculated { get; set; }
    }
}
