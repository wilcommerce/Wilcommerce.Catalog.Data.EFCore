# Wilcommerce.Catalog.Data.EFCore
Contains an implementation of [Wilcommerce.Catalog](https://github.com/wilcommerce/Wilcommerce.Catalog) package using Entity Framework Core as persistence framework.

## Requirements
According to Entity Framework Core 3.1 requirements, this project is built using NETStandard 2.1 as Target Framework (See [https://docs.microsoft.com/it-it/ef/core/what-is-new/ef-core-3.0/breaking-changes#netstandard21](https://docs.microsoft.com/it-it/ef/core/what-is-new/ef-core-3.0/breaking-changes#netstandard21) for further informations).

This means it will not run on projects which target .NET Framework.

If you have some specific needs you can [open a issue on GitHub](https://github.com/wilcommerce/Wilcommerce.Catalog.Data.EFCore/issues) or you can consider to [contribute to Wilcommerce](CONTRIBUTING.md).

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

After the DbContext has been registered in the ServiceCollection, you need to add a migration using **donet** CLI or the **Package Manager Console**.
```
// Using dotnet CLI
dotnet ef migrations add -c Wilcommerce.Catalog.Data.EFCore.CatalogContext Initial

// Using Package Manager Console
EntityFrameworkCore\Add-Migration -Context Wilcommerce.Catalog.Data.EFCore.CatalogContext Initial
```

After this, you can update your database:
```
// Using dotnet CLI
dotnet ef database update -c Wilcommerce.Catalog.Data.EFCore.CatalogContext

// Using Package Manager Console
EntityFrameworkCore\Update-Database -Context Wilcommerce.Catalog.Data.EFCore.CatalogContext
```

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