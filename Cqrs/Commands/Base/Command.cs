namespace Cqrs.Commands.Base
{
    public abstract class Command<T>
    {
        public readonly T Dto;

        public Command(T dto)
        {
            Dto = dto;
        }
    }
}
