using System;

namespace Api.Common
{
    public class FacadeMapping<TFacade>
    {
        public readonly Type MappingType;
        public readonly TFacade Facade;

        public FacadeMapping(Type mappingType, TFacade facade)
        {
            MappingType = mappingType;
            Facade = facade;
        }
    }
}
