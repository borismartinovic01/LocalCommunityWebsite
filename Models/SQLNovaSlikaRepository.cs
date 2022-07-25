using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLNovaSlikaRepository:INovaSlikaRepository
    {
        private readonly AppDbContext context;

        public SQLNovaSlikaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public NovaSlika Add(NovaSlika novaSlika)
        {
            context.NoveSlike.Add(novaSlika);
            context.SaveChanges();
            return novaSlika;
        }

        public NovaSlika Delete(int id)
        {
            NovaSlika novaSlika = context.NoveSlike.Find(id);
            if (novaSlika != null)
            {
                context.NoveSlike.Remove(novaSlika);
                context.SaveChanges();
            }
            return novaSlika;
        }

        public NovaSlika Update(NovaSlika novaSlikaPromena)
        {
            var novaSlika = context.NoveSlike.Attach(novaSlikaPromena);
            novaSlika.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return novaSlikaPromena;
        }
        public IEnumerable<NovaSlika> GetNoveSlike()
        {
            return context.NoveSlike;
        }

        public NovaSlika GetNova(int Id)
        {
            return context.NoveSlike.Find(Id);
        }
    }
}
