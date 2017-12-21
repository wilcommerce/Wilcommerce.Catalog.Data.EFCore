using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="Brand"/> class
    /// </summary>
    public static class BrandMapping
    {
        /// <summary>
        /// Extension method. Maps the brand class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
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
