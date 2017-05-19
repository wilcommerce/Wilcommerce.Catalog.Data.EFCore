using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class ProductImageMapping
    {
        public static ModelBuilder MapProductImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>()
                .ToTable("Wilcommerce_ProductImages");

            return modelBuilder;
        }
    }
}
