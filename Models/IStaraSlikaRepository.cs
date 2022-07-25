using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface IStaraSlikaRepository
    {
        StaraSlika GetStara(int Id);
        StaraSlika Add(StaraSlika staraSlika);
        StaraSlika Update(StaraSlika staraSlikaPromena);
        StaraSlika Delete(int id);
        IEnumerable<StaraSlika> GetStareSlike();
    }
}
