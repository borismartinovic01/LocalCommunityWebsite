using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLVestiRepository : IVestiRepository
    {
        private readonly AppDbContext context;

        public SQLVestiRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Vesti Add(Vesti vesti)
        {
            context.Vesti.Add(vesti);
            context.SaveChanges();
            return vesti;
        }

        public Vesti Delete(int id)
        {
            Vesti vest = context.Vesti.Find(id);
            if (vest != null)
            {
                context.Vesti.Remove(vest);
                context.SaveChanges();
            }
            return vest;
        }

        public IEnumerable<Vesti> GetSveVesti()
        {
            return context.Vesti;
        }

        public Vesti GetVest(int Id)
        {
            return context.Vesti.Find(Id);          
        }

        public Vesti Update(Vesti vestiPromena)
        {
            var vest = context.Vesti.Attach(vestiPromena);
            vest.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return vestiPromena;
        }
    }
}
