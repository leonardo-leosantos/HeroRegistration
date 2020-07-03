using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository.Interface
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Heroi[]> GetAllHerois(bool? includeBattle = false);
        Task<Heroi> GetHeroiById(Guid Id, bool? includeBattle = false);

        Task<Batalha[]> GetAllBatalhas(bool? includeBattle = false);
        Task<Batalha> GetBatalhaById(Guid Id, bool? includeBattle = false);
    }
}
