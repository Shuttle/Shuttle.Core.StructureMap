# Shuttle.Core.StructureMap

> **Warning**
> This package has been deprecated in favour of [.NET Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).

```
PM> Install-Package Shuttle.Core.StructureMap
```

``` c#
var containerBuilder = new Registry();

var registry = new StructureMapComponentRegistry(containerBuilder);

// register all components

var resolver = new StructureMapComponentResolver(new Container(containerBuilder));
```
