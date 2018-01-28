using System;
using System.Collections.Generic;
using Shuttle.Core.Container;
using Shuttle.Core.Contract;
using StructureMap;

namespace Shuttle.Core.StructureMap
{
    public class StructureMapComponentRegistry : ComponentRegistry
    {
        private readonly IRegistry _registry;

        public StructureMapComponentRegistry(IRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            _registry = registry;
        }

        public override IComponentRegistry Register(Type dependencyType, Type implementationType, Lifestyle lifestyle)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");
            Guard.AgainstNull(implementationType, "implementationType");

	        base.Register(dependencyType, implementationType, lifestyle);

            try
            {
                switch (lifestyle)
                {
                    case Lifestyle.Transient:
                    {
                        _registry.For(dependencyType).Use(implementationType).Transient();

                        break;
                    }
                    default:
                    {
                        _registry.For(dependencyType).Use(implementationType).Singleton();

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

        public override IComponentRegistry RegisterCollection(Type dependencyType, IEnumerable<Type> implementationTypes, Lifestyle lifestyle)
        {
            Guard.AgainstNull(implementationTypes, "implementationTypes");

	        base.RegisterCollection(dependencyType, implementationTypes, lifestyle);

            foreach (var implementationType in implementationTypes)
            {
				try
				{
					switch (lifestyle)
					{
						case Lifestyle.Transient:
							{
								_registry.For(dependencyType).Use(implementationType).Transient();

								break;
							}
						default:
							{
								_registry.For(dependencyType).Use(implementationType).Singleton();

								break;
							}
					}
				}
				catch (Exception ex)
				{
					throw new TypeRegistrationException(ex.Message, ex);
				}
            }

            return this;
        }

        public override IComponentRegistry RegisterInstance(Type dependencyType, object instance)
        {
            Guard.AgainstNull(dependencyType, "dependencyType");
            Guard.AgainstNull(instance, "instance");

	        base.RegisterInstance(dependencyType, instance);

            try
            {
                _registry.For(dependencyType).Use(instance);
            }
            catch (Exception ex)
            {
                throw new TypeRegistrationException(ex.Message, ex);
            }

            return this;
        }

        public override IComponentRegistry RegisterGeneric(Type dependencyType, Type implementationType, Lifestyle lifestyle)
        {
            return Register(dependencyType, implementationType, lifestyle);
        }
    }
}