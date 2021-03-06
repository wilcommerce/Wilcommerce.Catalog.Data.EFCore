﻿using Microsoft.EntityFrameworkCore;
using System;
using Wilcommerce.Catalog.Models;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Test.Fixtures
{
    public class CatalogContextFixture : IDisposable
    {
        public CatalogContext Context { get; protected set; }

        public CatalogContextFixture()
        {
            BuildContext();
            PrepareData();
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
            var category = Category.Create("CAT01", "Category1", "category1");
            var child = Category.Create("CHILD01", "Child1", "child1");
            category.AddChild(child);

            Context.Categories.Add(category);

            var brand = Brand.Create("MyBrand", "mybrand");
            Context.Brands.Add(brand);

            var customAttribute = CustomAttribute.Create("color", "string");
            Context.CustomAttributes.Add(customAttribute);

            var product = Product.Create("EAN", "SKU", "First Product", "first-product");
            product.EnableTierPrices();
            product.AddTierPrice(1, 10, new Currency
            {
                Amount = 20,
                Code = "EUR"
            });

            product.AddReview("Alberto", 10);
            product.AddImage("/path/to/image.jpg", "MyImage", "image", true, DateTime.Now);
            product.AddAttribute(customAttribute, "#fff");
            product.AddMainCategory(category);
            product.SetVendor(brand);

            Context.Products.Add(product);

            Context.SaveChanges();
        }

        protected virtual void CleanData()
        {
            Context.ProductCategories.RemoveRange(Context.ProductCategories);
            Context.ProductAttributes.RemoveRange(Context.ProductAttributes);
            Context.ProductImages.RemoveRange(Context.ProductImages);
            Context.ProductReviews.RemoveRange(Context.ProductReviews);
            Context.TierPrices.RemoveRange(Context.TierPrices);
            Context.Products.RemoveRange(Context.Products);
            Context.CustomAttributes.RemoveRange(Context.CustomAttributes);
            Context.Brands.RemoveRange(Context.Brands);
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
