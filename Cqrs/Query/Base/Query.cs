using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Query.Base
{
    public abstract class Query<T>
    {
        public readonly T Dto;

        public Query(T dto)
        {
            Dto = dto;
        }
    }
}
