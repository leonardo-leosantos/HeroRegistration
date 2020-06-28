﻿using EFCore.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebApi.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=sa123456;Persist Security Info=True;User ID=sa;Initial Catalog=HERO_APP;Data Source=LEOSANT\\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
                entity.HasKey(e=> new { e.IdHeroi, e.IdBatalha })
            );
        }
    }
}
