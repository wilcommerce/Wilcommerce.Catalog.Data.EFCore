using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class BrandMapping
    {
        public static ModelBuilder MapBrand(this ModelBuilder modelBuilder)
        {
            var brandMapping = modelBuilder.Entity<Brand>();

            brandMapping
                .ToTable("Wilcommerce_Brands")
                .HasIndex(b => b.Url).IsUnique();

            brandMapping
                .HasOne(b => b.Seo);

            brandMapping
                .HasOne(b => b.Logo);

            brandMapping
                .Property(b => b.Products)
                .HasField("_products");

            brandMapping
                .Metadata
                .FindNavigation(nameof(Brand.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            return modelBuilder;
        }
    }
}
