using Microsoft.EntityFrameworkCore;
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
                .OwnsOne(b => b.Seo);

            brandMapping
                .OwnsOne(b => b.Logo);

            return modelBuilder;
        }
    }
}
