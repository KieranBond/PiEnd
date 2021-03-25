using Akka.Actor;
using Api.Common;
using Api.HttpEndpoint;
using System.Collections.Generic;

namespace Api.Actors
{
    public class HttpEndpointActor : ReceiveActor
    {
        public HttpEndpointActor(IEnumerable<FacadeMapping<IFacade>> facades)
        {
            var listener = new HttpEndpointListener<HttpStartup>(facades);
        }

        public static Props GetProps(IEnumerable<FacadeMapping<IFacade>> facades)
        {
            return Props.Create(() => new HttpEndpointActor(facades));
        }
    }
}
