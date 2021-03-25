using Api.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Api.HttpEndpoint
{
    public class HttpEndpointListener<TStartup> where TStartup : class
    {
        public HttpEndpointListener(IEnumerable<FacadeMapping<IFacade>> facades)
        {
            Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<TStartup>()
                    .ConfigureServices(services =>
                    {
                        foreach(var facade in facades)
                        {
                            services.AddSingleton(facade.MappingType, facade.Facade);
                        }
                    });
            })
            .Build()
            .StartAsync();
        }
    }
}
