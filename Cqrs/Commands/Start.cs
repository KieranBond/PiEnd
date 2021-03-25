using Cqrs.Commands.Base;

namespace Cqrs.Commands
{
    public class Start<T> : Command<T>
    {
        public Start(T dto) : base(dto)
        {
        }
    }
}