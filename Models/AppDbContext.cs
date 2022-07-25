using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<StaraSlika> StareSlike { get; set; }
        public DbSet<NovaSlika> NoveSlike { get; set; }
        public DbSet<Vesti> Vesti { get; set; }
        public DbSet<UmjetnickaSlika> UmjetnickeSlike { get; set; }
        public DbSet<Sponzor> Sponzori { get; set; }
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<Link> Linkovi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
