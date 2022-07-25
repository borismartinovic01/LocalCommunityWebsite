using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLLinkRepository : ILinkRepository
    {
        private readonly AppDbContext context;

        public SQLLinkRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Link Add(Link link)
        {
            context.Linkovi.Add(link);
            context.SaveChanges();
            return link;
        }

        public Link Delete(int id)
        {
            Link link = context.Linkovi.Find(id);
            if (link != null)
            {
                context.Linkovi.Remove(link);
                context.SaveChanges();
            }
            return link;
        }

        public IEnumerable<Link> GetLinkovi()
        {
            return context.Linkovi;
        }

        public Link GetLink(int Id)
        {
            return context.Linkovi.Find(Id);
        }

        public Link Update(Link linkPromena)
        {
            var link = context.Linkovi.Attach(linkPromena);
            link.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return linkPromena;
        }
    }
}
