namespace Cqrs.Response.Base
{
    public class Response<T>
    {
        public readonly T Dto;

        public Response(T dto)
        {
            Dto = dto;
        }
    }
}
