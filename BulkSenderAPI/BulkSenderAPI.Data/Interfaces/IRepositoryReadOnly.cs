﻿namespace BulkSenderAPI.Data
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {

    }
}
