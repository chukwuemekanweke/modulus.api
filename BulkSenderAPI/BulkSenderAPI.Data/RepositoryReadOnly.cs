﻿using dijitalu.Core.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BulkSenderAPI.Data
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
    {
        public RepositoryReadOnly(DbContext context) : base(context)
        {
        }
    }
}
