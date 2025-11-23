using CarbonForm.Core.Entities;

namespace CarbonForm.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositoryleri buraya eklemek yerine, generic olduğu için generic metod üzerinden alabiliriz.
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<int> CommitAsync(); // SaveChangesAsync
    }
}
