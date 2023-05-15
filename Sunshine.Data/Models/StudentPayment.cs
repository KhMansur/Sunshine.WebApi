using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class StudentPayment
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public DateTime RecievedTime { get; set; }
        
        public Student Student { get; set; }

        public Group Group { get; set; }

        public string? Description { get; set; }

        public bool isCalculated { get; set; }
    }
}
