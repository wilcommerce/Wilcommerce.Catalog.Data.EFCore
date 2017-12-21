# Wilcommerce.Catalog.Data.EFCore
Contains an implementation of [Wilcommerce.Catalog](https://github.com/wilcommerce/Wilcommerce.Catalog) package using Entity Framework Core as persistence framework.

## Installation
Nuget package available here

[https://www.nuget.org/packages/Wilcommerce.Catalog.Data.EFCore/](https://www.nuget.org/packages/Wilcommerce.Catalog.Data.EFCore/)

## Usage
Add the CatalogContext class to your project.

For example in an ASP.NET Core project add this line to the ConfigureServices method in Startup.cs
```<C#>
services.AddDbContext<CatalogContext>(options => // Specify your provider);
```
The CatalogContext is injected in the read model component and the Repository implementation.

## Read model Component
The CatalogDatabase class is the implementation of the [ICatalogDatabase](https://github.com/wilcommerce/Wilcommerce.Catalog/blob/master/src/Wilcommerce.Catalog/ReadModels/ICatalogDatabase.cs) interface.

It provides a facade to access all the readonly data.
It requires an instance of CatalogContext as constructor parameters.

## Repository Component
The Repository class is the implementation of the [IRepository](https://github.com/wilcommerce/Wilcommerce.Catalog/blob/master/src/Wilcommerce.Catalog/Repository/IRepository.cs) interface.

It provides all the methods useful for persist an Aggregate model. 
It requires a CatalogContext instance as constructor parameter.

# Contributing
If you want to contribute to Wilcommerce please, check the [CONTRIBUTING](CONTRIBUTING.md) file.