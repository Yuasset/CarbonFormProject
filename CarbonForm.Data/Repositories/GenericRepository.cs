using CarbonForm.Core.Entities;
using CarbonForm.Data.Contexts;
using CarbonForm.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarbonForm.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// Asenkron olarak yeni bir varlık ekler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Tüm varlıkları sorgulanabilir bir şekilde döner.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return dbSet.AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Belirtilen Id'ye sahip varlığı asenkron olarak döner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <summary>
        /// Belirtilen varlığı siler.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Belirtilen varlığı günceller.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        /// <summary>
        /// Belirtilen ifade ile eşleşen varlıkları sorgular.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }
    }
}