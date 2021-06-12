using BulkSenderAPI.Data;
using BulkSenderAPI.Model.DbContext;
using BulkSenderAPI.Service;
using BulkSenderAPI.Service.Factory;
using BulkSenderAPI.Service.Implementations;
using BulkSenderAPI.Service.Implementations.Interfaces;
using BulkSenderAPI.Service.Interfaces;
using BulkSenderAPI.Web3Integration;
using Microsoft.Extensions.DependencyInjection;

namespace dijitalu.WebApi.Infrastructure
{
    public static class DIRegister
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection serviceCollection)
        {


            #region Scoped Services

            serviceCollection.AddScoped<IUnitOfWork<ApplicationDbContext>, UnitOfWork<ApplicationDbContext>>();
            //serviceCollection.AddScoped<ILoggerManager, LoggerManager>();


            #endregion


            #region Transient Services

            #region Services Without Interface
            serviceCollection.AddTransient<Web3Utility>();


            #endregion

            #region Services With Interface
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IExcelReaderService, ExcelReaderService>();
            serviceCollection.AddTransient<IServiceFactory, ServiceFactory>();
            serviceCollection.AddTransient<IAccountPolicyService, AccountPolicyService>();


            #endregion

            #endregion

            #region Singleton Services

            #endregion

            return serviceCollection;
        }
    }
}
