using AutoMapper;
using BulkSenderAPI.Data;
using BulkSenderAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Implementations
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IServiceFactory _serviceFactory;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceFactory = serviceFactory;
        }
    }
}
