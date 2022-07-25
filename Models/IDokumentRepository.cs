using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public interface IDokumentRepository
    {
        Dokument GetDokument(int Id);
        Dokument Add(Dokument dokument);
        Dokument Update(Dokument dokumentPromena);
        Dokument Delete(int id);
        IEnumerable<Dokument> GetDokumenta();
    }
}
