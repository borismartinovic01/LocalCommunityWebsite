using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLSponzorRepository : ISponzorRepository
    {
        private readonly AppDbContext context;

        public SQLSponzorRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Sponzor Add(Sponzor sponzor)
        {
            context.Sponzori.Add(sponzor);
            context.SaveChanges();
            return sponzor;
        }

        public Sponzor Delete(int id)
        {
            Sponzor sponzor = context.Sponzori.Find(id);
            if (sponzor != null)
            {
                context.Sponzori.Remove(sponzor);
                context.SaveChanges();
            }
            return sponzor;
        }

        public Sponzor GetSponzor(int Id)
        {
            return context.Sponzori.Find(Id);
        }

        public IEnumerable<Sponzor> GetSveSponzore()
        {
            return context.Sponzori;
        }

        public Sponzor Update(Sponzor sponzorPromena)
        {
            var sponzor = context.Sponzori.Attach(sponzorPromena);
            sponzor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return sponzorPromena;
        }
    }
}
