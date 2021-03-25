using Cqrs.Commands.Base;

namespace Cqrs.Commands
{
    public class Stop<T> : Command<T>
    {
        public Stop(T dto) : base(dto)
        {
        }
    }
}