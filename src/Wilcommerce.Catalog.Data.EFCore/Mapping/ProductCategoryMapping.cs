using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class ProductCategoryMapping
    {
        public static ModelBuilder MapProductCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .ToTable("Wilcommerce_ProductCategories");

            return modelBuilder;
        }
    }
}
