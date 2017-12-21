using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="Product"/> class
    /// </summary>
    public static class ProductMapping
    {
        /// <summary>
        /// Extension method. Map the product class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
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
                .WithMany();

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
                .HasMany(p => p.Variants)
                .WithOne(p => p.MainProduct);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Variants))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void SetupTierPrices(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .HasMany(p => p.TierPrices)
                .WithOne(t => t.Product);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.TierPrices))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void SetupCategories(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.ProductCategories))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.ProductCategories))
                .SetField("_categories");
        }

        private static void SetupAttributes(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .HasMany(p => p.Attributes)
                .WithOne(a => a.Product);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Attributes))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void SetupReviews(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Reviews))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void SetupImages(this EntityTypeBuilder<Product> productMapping)
        {
            productMapping
                .HasMany(p => p.Images)
                .WithOne(i => i.Product);

            productMapping
                .Metadata
                .FindNavigation(nameof(Product.Images))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
