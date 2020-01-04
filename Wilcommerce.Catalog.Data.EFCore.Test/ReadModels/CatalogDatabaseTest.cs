using Newtonsoft.Json;
using System.Linq;
using Wilcommerce.Catalog.Data.EFCore.ReadModels;
using Wilcommerce.Catalog.Data.EFCore.Test.Fixtures;
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
        public void Brands_Should_Contain_A_Brand_Named_MyBrand()
        {
            var brands = _database.Brands.Any(b => b.Name == "MyBrand");
            Assert.True(brands);
        }

        [Fact]
        public void Categories_Should_Contain_A_Category_With_Code_CAT01_And_One_Children()
        {
            var category = _database.Categories.Where(c => c.Code == "CAT01").FirstOrDefault();
            Assert.NotNull(category);
            Assert.True(category.Children.Count == 1);
        }

        [Fact]
        public void Categories_Should_Contain_A_Category_With_Code_CHILD01_And_A_Parent()
        {
            var category = _database.Categories.Where(c => c.Code == "CHILD01").FirstOrDefault();
            Assert.NotNull(category);
            Assert.NotNull(category.Parent);
            Assert.Equal("CAT01", category.Parent.Code);
        }

        [Fact]
        public void CustomAttributes_Must_Contains_A_Color_Attribute()
        {
            var attribute = _database.CustomAttributes.Any(a => a.Name == "color");
            Assert.True(attribute);
        }

        [Fact]
        public void Products_Must_Have_AtLeast_One_Record()
        {
            var products = _database.Products;
            Assert.NotEmpty(products);
        }

        [Fact]
        public void Products_Should_Contain_A_Product_With_A_Tier_Price_With_Quantity_From_1_To_10_And_Price_Amount_Equal_To_20()
        {
            var product = _database.Products.Where(p => p.TierPrices.Count > 0).FirstOrDefault();
            var tierPrice = product?.TierPrices.FirstOrDefault(t => t.FromQuantity == 1 && t.ToQuantity == 10 && t.Price.Amount == 20);

            Assert.NotNull(product);
            Assert.NotNull(tierPrice);
        }

        [Fact]
        public void Products_Should_Contain_A_Product_With_A_Review_By_Alberto_And_With_A_Rating_Of_10()
        {
            var product = _database.Products.Where(p => p.Reviews.Count > 0).FirstOrDefault();
            var review = product.Reviews.FirstOrDefault(r => r.Name == "Alberto" && r.Rating == 10);

            Assert.NotNull(product);
            Assert.NotNull(review);
        }

        [Fact]
        public void Products_Should_Contain_A_Product_With_An_Image_Marked_As_Main_And_With_Name_Equal_To_MyImage()
        {
            var product = _database.Products.Where(p => p.Images.Count > 0).FirstOrDefault();
            var image = product.Images.FirstOrDefault(i => i.IsMain && i.Name == "MyImage");

            Assert.NotNull(product);
            Assert.NotNull(image);
        }

        [Fact]
        public void Products_Should_Contain_A_Product_With_A_Custom_Attribute_Named_Color_And_With_A_Value_Equal_To_White_Code()
        {
            string value = JsonConvert.SerializeObject("#fff");

            var product = _database.Products.Where(p => p.Attributes.Count > 0).FirstOrDefault();
            var attribute = product.Attributes.FirstOrDefault(a => a.Attribute.Name == "color" && a._Value == value);

            Assert.NotNull(product);
            Assert.NotNull(attribute);
        }

        [Fact]
        public void Products_Should_Contain_A_Product_With_A_Category_Marked_As_Main_And_With_Code_Equal_To_CAT01()
        {
            var product = _database.Products.Where(p => p.ProductCategories.Any(c => c.IsMain)).FirstOrDefault();
            var category = product.ProductCategories.FirstOrDefault(c => c.IsMain && c.Category.Code == "CAT01");

            Assert.NotNull(product);
            Assert.NotNull(category);
        }

        [Fact]
        public void Products_Should_Contain_A_Product_With_A_Vendor_Named_MyBrand()
        {
            var product = _database.Products.Where(p => p.Vendor != null && p.Vendor.Name == "MyBrand").FirstOrDefault();
            Assert.NotNull(product);
            Assert.NotNull(product.Vendor);
        }
    }
}
