using NUnit.Framework;
using Shuttle.Core.Container.Tests;
using StructureMap;

namespace Shuttle.Core.StructureMap.Tests
{
    [TestFixture]
    public class StructureMapComponentContainerFixture : ContainerFixture
    {
        [Test]
        public void Should_be_able_resolve_all_instances()
        {
            var containerBuilder = new Registry();

            var registry = new StructureMapComponentRegistry(containerBuilder);

            RegisterCollection(registry);

            var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

            ResolveCollection(resolver);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_a_singleton()
        {
            var containerBuilder = new Registry();

            var registry = new StructureMapComponentRegistry(containerBuilder);

            RegisterSingleton(registry);

            var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

            ResolveSingleton(resolver);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_transient_components()
        {
            var containerBuilder = new Registry();

            var registry = new StructureMapComponentRegistry(containerBuilder);

            RegisterTransient(registry);

            var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

            ResolveTransient(resolver);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_an_open_generic_singleton()
        {
            var containerBuilder = new Registry();

            var registry = new StructureMapComponentRegistry(containerBuilder);

            RegisterSingletonGeneric(registry);

            var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

            ResolveSingletonGeneric(resolver);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_transient_open_generic_components()
        {
            var containerBuilder = new Registry();

            var registry = new StructureMapComponentRegistry(containerBuilder);

            RegisterTransientGeneric(registry);

            var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

            ResolveTransientGeneric(resolver);
        }

		[Test]
		public void Should_be_able_to_register_and_resolve_a_multiple_singleton()
		{
			var containerBuilder = new Registry();

			var registry = new StructureMapComponentRegistry(containerBuilder);

			RegisterMultipleSingleton(registry);

			var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

			ResolveMultipleSingleton(resolver);
		}

		[Test]
		public void Should_be_able_to_register_and_resolve_multiple_transient_components()
		{
			var containerBuilder = new Registry();

			var registry = new StructureMapComponentRegistry(containerBuilder);

			RegisterMultipleTransient(registry);

			var resolver = new StructureMapComponentResolver(new global::StructureMap.Container(containerBuilder));

			ResolveMultipleTransient(resolver);
		}
	}
}