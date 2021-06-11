using System;
using System.Collections.Generic;
using System.Text;

namespace BulkSenderAPI.Data
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {

    }
}
