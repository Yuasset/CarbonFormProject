using CarbonForm.Core.Entities;
using CarbonForm.Data.Contexts;
using CarbonForm.Data.Interfaces;

namespace CarbonForm.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        // Repositoryleri tek sefer oluşturup tekrar kullanmak için dictionary
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Tüm değişiklikleri veritabanına kaydeder.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        // IDisposable implementasyonu, scope sonlandığında DI aracılığıyla context'i dispose eder
        /// <summary>
        /// Tüm kaynakları serbest bırakır.
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }

        /// <summary>
        /// Generic repository örneğini döner. Aynı tür için tekrar çağrıldığında önceden oluşturulmuş repository'yi döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(context);
            repositories.Add(typeof(T), repository);
            return repository;
        }
    }
}