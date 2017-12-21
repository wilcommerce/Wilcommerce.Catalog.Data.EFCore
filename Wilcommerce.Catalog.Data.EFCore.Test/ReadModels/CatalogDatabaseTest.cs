using System.Linq;
using Wilcommerce.Catalog.Data.EFCore.ReadModels;
using Wilcommerce.Catalog.Data.EFCore.Test.Fixtures;
using Wilcommerce.Catalog.ReadModels;
using Xunit;

namespace Wilcommerce.Catalog.Data.EFCore.Test.ReadModels
{
    public class CatalogDatabaseTest : IClassFixture<CatalogContextFixture>
    {
        private CatalogContextFixture _fixture;

        private CatalogDatabase _database;

        public CatalogDatabaseTest(CatalogContextFixture fixture)
        {
            _fixture = fixture;
            _database = new CatalogDatabase(_fixture.Context);
        }
        
        [Fact]
        public void Products_Must_Have_AtLeast_One_Record()
        {
            var products = _database.Products;
            Assert.NotEmpty(products);
        }

        [Fact]
        public void CustomAttributes_Must_Contains_A_Color_Attribute()
        {
            var attribute = _database.CustomAttributes.Any(a => a.Name == "color");
            Assert.True(attribute);
        }

        [Fact]
        public void Product_Must_Contains_TierPrices()
        {
            var product = _database.Products.Active().FirstOrDefault();
            Assert.NotNull(product);

            Assert.True(product.TierPrices.Any());
        }
    }
}
