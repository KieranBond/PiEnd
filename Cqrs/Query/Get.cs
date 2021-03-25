using Cqrs.Query.Base;

namespace Cqrs.Query
{
    public class Get<T> : Query<T>
    {
        public Get(T dto) : base(dto)
        {
        }
    }
}
