using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class EmailMessage
    {

        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
