using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.Data.EFCore.ReadModels;
using Wilcommerce.Catalog.Data.EFCore.Test.Fixtures;
using Wilcommerce.Catalog.Models;
using Wilcommerce.Catalog.ReadModels;
using Wilcommerce.Core.Common.Models;
using Wilcommerce.Core.Infrastructure;
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
        public async Task Add_New_Product_Should_Increment_Products_Number()
        {
            var productsCount = _database.Products.Count();

            var product = Product.Create("EAN", "SKU", "Product #1", "product-1");
            _repository.Add(product);
            await _repository.SaveChangesAsync();

            Assert.Equal(productsCount + 1, _database.Products.Count());
        }

        [Fact]
        public async Task GetByKey_Should_Return_The_Product_Found()
        {
            var productId = _database.Products.FirstOrDefault(p => p.Name == "First Product" && p.Url == "first-product").Id;
            var product = await _repository.GetByKeyAsync<Product>(productId);

            Assert.NotNull(product);
            Assert.Equal("First Product", product.Name);
            Assert.Equal("first-product", product.Url);
        }

        [Fact]
        public async Task Edit_Product_Information_Should_Change_Product_Values()
        {
            var product = _database.Products.FirstOrDefault(p => p.Name == "First Product" && p.Url == "first-product");
            
            Guid productId = product.Id;
            string ean = "newEAN";
            string sku = "newSKU";
            string name = "First Product";
            string url = "first-product";
            Currency price = new Currency { Code = "EUR", Amount = 10 };
            string description = "description";
            int unitInStock = 2;
            bool isOnSale = true;
            DateTime? onSaleFrom = DateTime.Today;
            DateTime? onSaleTo = DateTime.Today.AddMonths(6);

            var eventBus = new Mock<IEventBus>().Object;
            var commands = new ProductCommands(_repository, eventBus);

            await commands.UpdateProductInfo(productId, ean, sku, name, url, price, description, unitInStock, isOnSale, onSaleFrom, onSaleTo);

            Assert.Equal(ean, product.EanCode);
            Assert.Equal(sku, product.Sku);
            Assert.Equal(name, product.Name);
            Assert.Equal(url, product.Url);
            Assert.Equal(price, product.Price);
            Assert.Equal(description, product.Description);
            Assert.Equal(unitInStock, product.UnitInStock);
            Assert.Equal(isOnSale, product.IsOnSale);
            Assert.Equal(onSaleFrom, product.OnSaleFrom);
            Assert.Equal(onSaleTo, product.OnSaleTo);
        }

        [Fact]
        public async Task AddProductVariant_Should_Add_Variant_Correctly()
        {
            var product = _database.Products.FirstOrDefault(p => p.Name == "First Product" && p.Url == "first-product");

            var eventBus = new Mock<IEventBus>().Object;
            var commands = new ProductCommands(_repository, eventBus);

            Guid productId = product.Id;
            string name = "first product variant";
            string ean = "Ean001";
            string sku = "Sku001";
            Currency price = new Currency { Code = "EUR", Amount = 100 };

            await commands.AddProductVariant(productId, name, ean, sku, price);

            var variantAdded = _database.Products.VariantsOf(productId).FirstOrDefault(v => v.EanCode == ean && v.Sku == sku);

            Assert.NotNull(variantAdded);
            Assert.Equal(name, variantAdded.Name);
            Assert.Equal(ean, variantAdded.EanCode);
            Assert.Equal(sku, variantAdded.Sku);
            Assert.Equal(price, variantAdded.Price);
        }
    }
}
