using System.Linq;
using Wilcommerce.Catalog.Data.EFCore.ReadModels;
using Wilcommerce.Catalog.Data.EFCore.Test.Fixtures;
using Wilcommerce.Catalog.Models;
using Xunit;

namespace Wilcommerce.Catalog.Data.EFCore.Test.Repository
{
    public class RepositoryTest : IClassFixture<CatalogContextFixture>
    {
        private CatalogContextFixture _fixture;

        private EFCore.Repository.Repository _repository;

        private CatalogDatabase _database;

        public RepositoryTest(CatalogContextFixture fixture)
        {
            _fixture = fixture;
            _repository = new EFCore.Repository.Repository(_fixture.Context);
            _database = new CatalogDatabase(_fixture.Context);
        }

        [Fact]
        public void Add_New_Product_Should_Increment_Products_Number()
        {
            var productsCount = _database.Products.Count();

            var product = Product.Create("EAN", "SKU", "Product #1", "product-1");
            _repository.Add(product);
            _repository.SaveChanges();

            Assert.Equal(productsCount + 1, _database.Products.Count());
        }

        [Fact]
        public void GetByKey_Should_Return_The_Product_Found()
        {
            var productId = _database.Products.FirstOrDefault(p => p.Name == "First Product" && p.Url == "first-product").Id;
            var product = _repository.GetByKey<Product>(productId);

            Assert.NotNull(product);
            Assert.Equal("First Product", product.Name);
            Assert.Equal("first-product", product.Url);
        }
    }
}
