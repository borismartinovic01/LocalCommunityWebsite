using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface INovaSlikaRepository
    {
        NovaSlika GetNova(int Id);
        NovaSlika Add(NovaSlika novaSlika);
        NovaSlika Update(NovaSlika novaSlikaPromena);
        NovaSlika Delete(int id);
        IEnumerable<NovaSlika> GetNoveSlike();
    }
}
