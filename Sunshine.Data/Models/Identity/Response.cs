using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public IList<string> Roles { get; set; }

        public Response()
        {
            Roles = new List<string>();
        }
    }
}
