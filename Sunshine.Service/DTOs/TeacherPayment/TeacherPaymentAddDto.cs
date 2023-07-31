using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.DTOs.TeacherPayment
{
    public class TeacherPaymentAddDto
    {
        public Guid TeacherId { get; set; }

        public IList<Guid> StudentPaymentIds { get; set; }

        public string? Description { get; set; }
    }
}
