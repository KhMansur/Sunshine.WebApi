using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Chat
    {
        public Guid Id { get; set; }

        public IList<Message> Messages { get; set; }

        public Guid FirstOwnerId { get; set; }

        public Guid SecondOwnerId { get; set; }

        public string CreatedTime { get; set; }

        public Chat() 
        {
            Messages = new List<Message>();
        }
    }
}
