using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class ProductMapping
    {
        public static ModelBuilder MapProducts(this ModelBuilder modelBuilder)
        {
            var productMapping = modelBuilder.Entity<Product>();

            productMapping
                .ToTable("Wilcommerce_Products")
                .HasIndex(p => p.EanCode).IsUnique();

            productMapping
                .HasIndex(p => p.Sku).IsUnique();

            productMapping
                .HasIndex(p => p.Url).IsUnique();

            productMapping
                .OwnsOne(p => p.Seo);
            
            productMapping
                .OwnsOne(p => p.Price);

            productMapping
                .HasOne(p => p.Vendor)
                .WithMany(b => b.Products);

            productMapping
                .SetupTierPrices();

            productMapping
                .SetupVariants();

            productMapping
                .SetupCategories();

            productMapping
                .SetupAttributes();

            productMapping
                .SetupReviews();

            productMapping
                .SetupImages();

            productMapping
                .Ignore(p => p.Categories)
                .Ignore(p => p.MainCategory);

            return modelBuilder;
        }
        
        private static void SetupVariants(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .Property(p => p.Variants)
                .HasField("_variants");

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Variants))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .HasMany(p => p.Variants)
                .WithOne(p => p.MainProduct);
        }

        private static void SetupTierPrices(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .Property(p => p.TierPrices)
                .HasField("_tierPrices");

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.TierPrices))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .HasMany(p => p.TierPrices)
                .WithOne(t => t.Product);
        }

        private static void SetupCategories(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .Property(p => p.ProductCategories)
                .HasField("_categories");

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.ProductCategories))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);
        }

        private static void SetupAttributes(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .Property(p => p.Attributes)
                .HasField("_attributes");

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Attributes))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .HasMany(p => p.Attributes)
                .WithOne(a => a.Product);
        }

        private static void SetupReviews(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .Property(p => p.Reviews)
                .HasField("_reviews");

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Reviews))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product);
        }

        private static void SetupImages(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .Property(p => p.Images)
                .HasField("_images");

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Images))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .HasMany(p => p.Images)
                .WithOne(i => i.Product);
        }
    }
}
