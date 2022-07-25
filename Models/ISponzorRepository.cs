using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface ISponzorRepository
    {
        Sponzor GetSponzor(int Id);
        Sponzor Add(Sponzor sponzor);
        Sponzor Update(Sponzor sponzorPromena);
        Sponzor Delete(int id);
        IEnumerable<Sponzor> GetSveSponzore();
    }
}
