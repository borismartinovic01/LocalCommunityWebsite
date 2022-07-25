using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}
