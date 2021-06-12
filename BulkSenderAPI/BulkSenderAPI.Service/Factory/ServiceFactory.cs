using BulkSenderAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Service.Factory
{
    public class ServiceFactory : IServiceFactory
    {

        IServiceProvider ServiceProvider { get; set; }
        public ServiceFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }


        public T GetService<T>() where T : class
        {
            T service = ServiceProvider.GetService(typeof(T)) as T;
            if (service == null)
                throw new Exception("Type Not Supported");
            return service;
        }

    }
}
