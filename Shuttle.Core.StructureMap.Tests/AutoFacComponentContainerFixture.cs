using NUnit.Framework;
using Shuttle.Core.Castle.Tests;
using Shuttle.Core.Infrastructure;
using StructureMap;

namespace Shuttle.Core.StructureMap.Tests
{
    [TestFixture]
    public class StructureMapComponentContainerFixture
    {
        [Test]
        public void Should_be_able_to_register_and_resolve_a_type()
        {
            var serviceType = typeof(IDoSomething);
            var implementationType = typeof(DoSomething);
            var bogusType = typeof(INotRegistered);
            var builder = new Registry();

            var registry = new StructureMapComponentRegistry(builder);

            registry.Register(serviceType, implementationType, Lifestyle.Singleton);

            var resolver = new StructureMapComponentResolver(new Container(builder));

            Assert.NotNull(resolver.Resolve(serviceType));
            Assert.AreEqual(implementationType, resolver.Resolve(serviceType).GetType());
            Assert.Throws<TypeResolutionException>(() => resolver.Resolve(bogusType));
        }

        [Test]
        public void Should_be_able_to_use_constructor_injection()
        {
            var serviceType = typeof (IDoSomething);
            var implementationType = typeof (DoSomethingWithDependency);
            var someDependency = new SomeDependency();
            var builder = new Registry();

            var registry = new StructureMapComponentRegistry(builder);

            registry.Register(serviceType, implementationType, Lifestyle.Singleton);
            registry.Register(typeof(ISomeDependency), someDependency);

            var resolver = new StructureMapComponentResolver(new Container(builder));

            Assert.AreSame(someDependency, resolver.Resolve<IDoSomething>().SomeDependency);
        }
    }
}