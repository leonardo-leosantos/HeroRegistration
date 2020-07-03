using EFCore.Domain;
using EFCore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository.Implementation
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroiContext _context;
        public EFCoreRepository(HeroiContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Heroi[]> GetAllHerois(bool? includeBattle = false)
        {
            IQueryable<Heroi> query = _context.Herois
                                      .Include(h => h.Identidade)
                                      .Include(h => h.Armas);

            if(includeBattle.Value)
                query = query.Include(h => h.HeroiBatalhas)
                            .ThenInclude(heroBattle => heroBattle.Batalha);
            
            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Heroi> GetHeroiById(Guid Id, bool? includeBattle = false)
        {
            //IQueryable<Heroi> query = _context.Herois
            //                          .Include(h => h.Identidade)
            //                          .Include(h => h.Armas);

            //if (includeBattle.Value)
            //    query = query.Include(h => h.HeroiBatalhas)
            //                .ThenInclude(heroBattle => heroBattle.Batalha);

            //query = query.AsNoTracking().Where(h => h.Id == Id);

            //return await query.FirstOrDefaultAsync();

            Heroi heroi = await _context.Herois
               .Include(h => h.Identidade)
              .Include(h => h.Armas)
              .AsNoTracking()
              .FirstOrDefaultAsync(e => e.Id == Id);

            return heroi;
        }

        public async Task<Batalha[]> GetAllBatalhas(bool? includeBattle = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (includeBattle.Value)
                query = query.Include(b => b.HeroiBatalhas)
                            .ThenInclude(heroBattle => heroBattle.Heroi);

            query = query.AsNoTracking().OrderBy(b => b.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Batalha> GetBatalhaById(Guid Id, bool? includeBattle = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (includeBattle.Value)
                query = query.Include(b => b.HeroiBatalhas)
                            .ThenInclude(heroBattle => heroBattle.Batalha);

            query = query.AsNoTracking().OrderBy(b => b.Id);

            return await query.FirstOrDefaultAsync(b => b.Id == Id);
        }
    }
}
