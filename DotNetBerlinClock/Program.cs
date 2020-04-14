using BerlinClock;
using DotNetBerlinClock.ServiceContainer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNetBerlinClock
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollectionFactory = new ServiceCollectionsFactory(new ServiceCollection());
            var service = serviceCollectionFactory.ServiceProvider<ITimeConverter>();

            Console.WriteLine("Enter a time.");

            var time = Console.ReadLine();
            var timeMatrix = service.convertTime(time);

            Console.WriteLine(timeMatrix);
            Console.Read();
        }
    }
}