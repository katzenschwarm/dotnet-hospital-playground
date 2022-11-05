using HMS.Repositories;
using HMS.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Services.Infrastructure.Depencency
{
    public static class RepositoriesDependencyExtensions
    {
        /// <summary>
        /// Extension for Dependency Injection to setup a default configuration of repositories.
        /// </summary>
        /// <param name="serviceCollection">Service collection to extend</param>
        public static void RegisterApplicationRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRoomRepository, RoomRepository>();

            // not possible with default DI, need to use SimpleInjector
            // serviceCollection.AddTransient<IRoomRepository, BaseRepository<Room, int>>();
        }
    }
}
