using BulkSenderAPI.Model.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dijitalu.WebApi.Infrastructure
{

    public static class ConfigurationRegister
    {
        public static IServiceCollection RegisterConfigurations(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            AppSettings appSettings = new AppSettings();

            configuration.GetSection("AppSettings").Bind(appSettings);

            serviceCollection.AddTransient<AppSettings>((x)=> appSettings);

            return serviceCollection;
        }
    }

}
