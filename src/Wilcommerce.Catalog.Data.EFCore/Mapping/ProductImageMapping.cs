using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="ProductImage"/> class
    /// </summary>
    public static class ProductImageMapping
    {
        /// <summary>
        /// Extension method. Map the product image class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapProductImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>()
                .ToTable("Wilcommerce_ProductImages");

            return modelBuilder;
        }
    }
}
