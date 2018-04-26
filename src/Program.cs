﻿using Microsoft.Extensions.DependencyInjection;
using SwgAnh.Docker.Contracts;
using SwgAnh.Docker.Infrastructure;
using SwgAnh.Docker.Infrastructure.SwgAnhServer;

namespace SwgAnh.Docker
{
    static class Program
    {
        /**
         *    Main startup for SWGANH server
         */
        private static void Main(string[] args)
        {
            var serviceCollection = ConfigureDependencyInjection();
            var swgServer = serviceCollection.GetService<ISwgServer>();
            swgServer.Run();
        }

        private static ServiceProvider ConfigureDependencyInjection()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILoginServer, LoginServerClient>()
                .AddTransient<ISwgServer, SwgServer>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}