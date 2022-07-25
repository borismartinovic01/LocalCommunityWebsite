using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLStaraSlikaRepository : IStaraSlikaRepository
    {
        private readonly AppDbContext context;

        public SQLStaraSlikaRepository(AppDbContext context)
        {
            this.context = context;
        }
        public StaraSlika Add(StaraSlika staraSlika)
        {
            context.StareSlike.Add(staraSlika);
            context.SaveChanges();
            return staraSlika;
        }

        public StaraSlika Delete(int id)
        {
            StaraSlika staraSlika = context.StareSlike.Find(id);
            if (staraSlika != null)
            {
                context.StareSlike.Remove(staraSlika);
                context.SaveChanges();
            }
            return staraSlika;
        }

        public StaraSlika Update(StaraSlika staraSlikaPromena)
        {
            var staraSlika = context.StareSlike.Attach(staraSlikaPromena);
            staraSlika.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return staraSlikaPromena;
        }
        public IEnumerable<StaraSlika> GetStareSlike()
        {
            return context.StareSlike;
        }

        public StaraSlika GetStara(int Id)
        {
            return context.StareSlike.Find(Id);
        }
    }
}
