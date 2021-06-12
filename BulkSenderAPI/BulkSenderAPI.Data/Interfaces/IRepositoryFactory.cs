using BulkSenderAPI.Model.Entities;

namespace BulkSenderAPI.Data
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        IRepositoryReadOnly<T> GetReadOnlyRepository<T>() where T : BaseEntity;
    }
}
