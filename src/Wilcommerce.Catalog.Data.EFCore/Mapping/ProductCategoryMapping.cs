using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="ProductCategory"/> class
    /// </summary>
    public static class ProductCategoryMapping
    {
        /// <summary>
        /// Extension method. Map the product category class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapProductCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .ToTable("Wilcommerce_ProductCategories")
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            return modelBuilder;
        }
    }
}
