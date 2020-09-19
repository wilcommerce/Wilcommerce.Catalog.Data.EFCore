using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="ProductReview"/> class
    /// </summary>
    public static class ProductReviewMapping
    {
        /// <summary>
        /// Extension method. Map the product review class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapProductReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReview>()
                .ToTable("Wilcommerce_ProductReviews")
                .HasKey(pr => pr.Id);

            modelBuilder.Entity<ProductReview>()
                .Property(pr => pr.Id)
                .ValueGeneratedNever();

            return modelBuilder;
        }
    }
}
