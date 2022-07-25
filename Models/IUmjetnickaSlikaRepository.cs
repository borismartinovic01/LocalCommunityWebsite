using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface IUmjetnickaSlikaRepository
    {
        UmjetnickaSlika GetSlika(int Id);
        UmjetnickaSlika Add(UmjetnickaSlika umjetnickaSlika);
        UmjetnickaSlika Update(UmjetnickaSlika umjetnickaSlikaPromena);
        UmjetnickaSlika Delete(int id);
        IEnumerable<UmjetnickaSlika> GetUmjetnickeSlike();
    }
}
