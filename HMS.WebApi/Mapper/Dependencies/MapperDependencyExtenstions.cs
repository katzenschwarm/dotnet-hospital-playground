using System.Reflection;

namespace HMS.WebApi.Mapper.Dependencies
{
    public static class MapperDependencyExtenstions
    {
        public static void RegisterApplicationMappers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

            // verify maps configs
        }
    }
}
