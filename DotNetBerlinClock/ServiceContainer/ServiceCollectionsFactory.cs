using BerlinClock;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBerlinClock.ServiceContainer
{
    public class ServiceCollectionsFactory
    {
        private IServiceCollection collection;
        private ServiceProvider serviceProvider;

        public ServiceCollectionsFactory(IServiceCollection collection)
        {
            this.collection = collection;
            collection.AddScoped<ITimeConverter, TimeConverter>();
            this.serviceProvider = collection.BuildServiceProvider();
        }

        public T ServiceProvider<T>()
        {
            return this.serviceProvider.GetService<T>();
        }

        public void DisposeServiceProvider()
        {
            serviceProvider.Dispose();
        }
    }
}