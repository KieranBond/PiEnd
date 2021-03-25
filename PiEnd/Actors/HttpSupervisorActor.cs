using Akka.Actor;
using Api.Common;
using System.Collections.Generic;

namespace Api.Actors
{
    public class HttpSupervisorActor : ReceiveActor
    {
        private IActorRef _httpEndpointActor;
        public HttpSupervisorActor(IEnumerable<FacadeMapping<IFacade>> facades)
        {
            var props = HttpEndpointActor.GetProps(facades);
            _httpEndpointActor = Context.ActorOf(props);
        }

        public static Props GetProps(IEnumerable<FacadeMapping<IFacade>> facades)
        {
            return Props.Create(() => new HttpSupervisorActor(facades));
        }
    }
}
