using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class ProductReviewMapping
    {
        public static ModelBuilder MapProductReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReview>()
                .ToTable("Wilcommerce_ProductReviews");

            return modelBuilder;
        }
    }
}
