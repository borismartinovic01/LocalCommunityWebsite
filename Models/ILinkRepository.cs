using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface ILinkRepository
    {
        Link GetLink(int Id);
        Link Add(Link link);
        Link Update(Link linkPromena);
        Link Delete(int id);
        IEnumerable<Link> GetLinkovi();
    }
}
