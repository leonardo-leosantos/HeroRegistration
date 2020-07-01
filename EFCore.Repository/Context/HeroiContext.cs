using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class HeroiContext : DbContext
    {
        public HeroiContext(DbContextOptions<HeroiContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
                entity.HasKey(e => new { e.IdHeroi, e.IdBatalha })
            );

            //MAPS//

            //HEROI -> ARMAS
            modelBuilder.Entity<Heroi>()
                        .HasMany(b => b.Armas)
                        .WithOne()
                        .HasForeignKey(x=> x.IdHeroi);

            //HEROI -> IDENTIDADE SECRETA
            modelBuilder.Entity<Heroi>()
                        .HasOne(b => b.Identidade)
                        .WithOne(i => i.Heroi)
                        .HasForeignKey<IdentidadeSecreta>(b => b.IdHeroi);

            //HEROIS_BATALHAS -> muitos p muitos
            modelBuilder.Entity<HeroiBatalha>()
                        .HasOne(hb => hb.Heroi)
                        .WithMany(h => h.HeroiBatalhas)
                        .HasForeignKey(hb => hb.IdHeroi);

            modelBuilder.Entity<HeroiBatalha>()
                        .HasOne(hb => hb.Batalha)
                        .WithMany(b => b.HeroiBatalhas)
                        .HasForeignKey(hb => hb.IdBatalha);
        }
    }
}
