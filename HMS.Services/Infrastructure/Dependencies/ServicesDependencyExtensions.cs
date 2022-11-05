using HMS.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Services.Infrastructure.Depencency
{
    public static class ServicesDependencyExtensions
    {
        /// <summary>
        /// Extension for Dependency Injection to setup a default configuration of services.
        /// </summary>
        /// <param name="serviceCollection">Service collection to extend</param>
        public static void RegisterApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRoomService, RoomService>();
        }
    }
}
