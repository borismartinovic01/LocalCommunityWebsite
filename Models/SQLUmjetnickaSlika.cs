using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLUmjetnickaSlika : IUmjetnickaSlikaRepository
    {
        private readonly AppDbContext context;

        public SQLUmjetnickaSlika(AppDbContext context)
        {
            this.context = context;
        }
        public UmjetnickaSlika Add(UmjetnickaSlika umjetnickaSlika)
        {
            context.UmjetnickeSlike.Add(umjetnickaSlika);
            context.SaveChanges();
            return umjetnickaSlika;
        }

        public UmjetnickaSlika Delete(int id)
        {
            UmjetnickaSlika umjetnickaSlika = context.UmjetnickeSlike.Find(id);
            if (umjetnickaSlika != null)
            {
                context.UmjetnickeSlike.Remove(umjetnickaSlika);
                context.SaveChanges();
            }
            return umjetnickaSlika;
        }

        public UmjetnickaSlika GetSlika(int Id)
        {
            return context.UmjetnickeSlike.Find(Id);
        }

        public IEnumerable<UmjetnickaSlika> GetUmjetnickeSlike()
        {
            return context.UmjetnickeSlike;
        }

        public UmjetnickaSlika Update(UmjetnickaSlika umjetnickaSlikaPromena)
        {
            var umjetnickaSlika = context.UmjetnickeSlike.Attach(umjetnickaSlikaPromena);
            umjetnickaSlika.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return umjetnickaSlikaPromena;
        }
    }
}
