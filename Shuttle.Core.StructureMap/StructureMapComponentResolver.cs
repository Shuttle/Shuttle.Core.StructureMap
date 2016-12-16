using System;
using System.Collections.Generic;
using System.Linq;
using Shuttle.Core.Infrastructure;
using StructureMap;

namespace Shuttle.Core.StructureMap
{
    public class StructureMapComponentResolver : IComponentResolver
    {
        private readonly IContainer _container;

        public StructureMapComponentResolver(IContainer container)
        {
            Guard.AgainstNull(container, "container");

            _container = container;
        }

        public object Resolve(Type serviceType)
        {
            Guard.AgainstNull(serviceType, "serviceType");

            try
            {
                return _container.GetInstance(serviceType);
            }
            catch (Exception ex)
            {
                throw new TypeResolutionException(ex.Message, ex);
            }
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            Guard.AgainstNull(serviceType, "serviceType");

            try
            {
                return _container.GetAllInstances(serviceType).Cast<object>();
            }
            catch (Exception ex)
            {
                throw new TypeResolutionException(ex.Message, ex);
            }
        }
    }
}