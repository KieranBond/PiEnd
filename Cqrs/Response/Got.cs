using Cqrs.Response.Base;

namespace Cqrs.Response
{
    public class Got<T> : Response<T>
    {
        public Got(T dto) : base(dto)
        {
        }
    }
}
