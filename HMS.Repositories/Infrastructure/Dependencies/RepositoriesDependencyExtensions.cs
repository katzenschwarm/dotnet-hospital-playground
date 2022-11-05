using HMS.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Repositories.Infrastructure.Dependencies
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
            serviceCollection.AddTransient<IDatabase, Database>();

            // not possible with default DI, need to use SimpleInjector
            // serviceCollection.AddTransient<IRoomRepository, BaseRepository<Room, int>>();
        }
    }
}
