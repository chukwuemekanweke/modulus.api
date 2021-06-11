using dijitalu.ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkSenderAPI.Data
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        IRepositoryReadOnly<T> GetReadOnlyRepository<T>() where T : BaseEntity;
    }
}
