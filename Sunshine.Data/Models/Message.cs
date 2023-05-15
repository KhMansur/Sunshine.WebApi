using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecieverId { get; set; }

        public string CreatedTime { get; set; }

        public string Text { get; set; }

        public Chat Chat { get; set; }
    }
}
