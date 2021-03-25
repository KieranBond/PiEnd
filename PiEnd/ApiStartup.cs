using Akka.Actor;
using Akka.DependencyInjection;
using Api.Actors;
using Api.Common;
using DiscordBot;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace PiEnd
{
    public class ApiStartup
    {
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        private ActorSystem _actorSystem;

        public ApiStartup(IConfiguration configuration, ILogger logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public void Start()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ILogger>(Logger);
            services.AddSingleton<IDiscordBotFacade, DiscordBotFacade>();

            var provider = services.BuildServiceProvider();
            var bootstrap = BootstrapSetup.Create();
            var di = ServiceProviderSetup.Create(provider);
            _actorSystem = ActorSystem.Create("PiEnd", bootstrap.And(di));

            var facades = new List<FacadeMapping<IFacade>>()
            {
                new FacadeMapping<IFacade>(typeof(IDiscordBotFacade), provider.GetService<IDiscordBotFacade>()),
            };

            var props = HttpSupervisorActor.GetProps(facades);
            var httpSuper = _actorSystem.ActorOf(props);
        }

        public void Stop()
        {
            _actorSystem.Terminate();
        }
    }
}
