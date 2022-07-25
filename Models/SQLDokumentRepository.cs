using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class SQLDokumentRepository : IDokumentRepository
    {
        private readonly AppDbContext context;

        public SQLDokumentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Dokument Add(Dokument dokument)
        {
            context.Dokumenti.Add(dokument);
            context.SaveChanges();
            return dokument;
        }

        public Dokument Delete(int id)
        {
            Dokument dokument = context.Dokumenti.Find(id);
            if (dokument != null)
            {
                context.Dokumenti.Remove(dokument);
                context.SaveChanges();
            }
            return dokument;
        }

        public Dokument GetDokument(int Id)
        {
            return context.Dokumenti.Find(Id);
        }

        public IEnumerable<Dokument> GetDokumenta()
        {
            return context.Dokumenti;
        }

        public Dokument Update(Dokument dokumentPromena)
        {
            var dokument = context.Dokumenti.Attach(dokumentPromena);
            dokument.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return dokumentPromena;
        }
    }
}
