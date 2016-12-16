using System;
using System.Collections.Generic;
using Shuttle.Core.Infrastructure;
using StructureMap;

namespace Shuttle.Core.StructureMap
{
    public class StructureMapComponentRegistry : IComponentRegistry
    {
        private readonly IRegistry _registry;

        public StructureMapComponentRegistry(IRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            _registry = registry;
        }

        public IComponentRegistry Register(Type serviceType, Type implementationType, Lifestyle lifestyle)
        {
            Guard.AgainstNull(serviceType, "serviceType");
            Guard.AgainstNull(implementationType, "implementationType");

            try
            {
                switch (lifestyle)
                {
                    case Lifestyle.Transient:
                    {
                        _registry.For(serviceType).Use(implementationType).Transient();

                        break;
                    }
                    default:
                    {
                        _registry.For(serviceType).Use(implementationType).Singleton();

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new TypeRegistrationException(ex.Message, ex);
            }

            return this;
        }

        public IComponentRegistry RegisterCollection(Type serviceType, IEnumerable<Type> implementationTypes, Lifestyle lifestyle)
        {
            Guard.AgainstNull(implementationTypes, "implementationTypes");

            foreach (var implementationType in implementationTypes)
            {
                Register(serviceType, implementationType, lifestyle);
            }

            return this;
        }

        public IComponentRegistry Register(Type serviceType, object instance)
        {
            Guard.AgainstNull(serviceType, "serviceType");
            Guard.AgainstNull(instance, "instance");

            try
            {
                _registry.For(serviceType).Use(instance);
            }
            catch (Exception ex)
            {
                throw new TypeRegistrationException(ex.Message, ex);
            }

            return this;
        }
    }
}