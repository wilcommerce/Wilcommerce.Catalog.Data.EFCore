using Microsoft.EntityFrameworkCore;
using System;

namespace Wilcommerce.Catalog.Data.EFCore.Test.Fixtures
{
    public class CatalogContextFixture : IDisposable
    {
        public CatalogContext Context { get; protected set; }

        public CatalogContextFixture()
        {
            BuildContext();
        }

        public void Dispose()
        {
            CleanData();
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        protected virtual void PrepareData()
        {

        }

        protected virtual void CleanData()
        {

        }

        protected virtual void BuildContext()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "InMemory-Catalog")
                .Options;

            Context = new CatalogContext(options);
        }
    }
}
