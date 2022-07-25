using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface IVestiRepository
    {
        Vesti GetVest(int Id);
        Vesti Add(Vesti vesti);
        Vesti Update(Vesti vestiPromena);
        Vesti Delete(int id);
        IEnumerable<Vesti> GetSveVesti();

    }
}
