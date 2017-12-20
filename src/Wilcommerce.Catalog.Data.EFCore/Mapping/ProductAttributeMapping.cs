using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class ProductAttributeMapping
    {
        public static ModelBuilder MapProductAttributes(this ModelBuilder modelBuilder)
        {
            var attributeMapping = modelBuilder.Entity<ProductAttribute>();

            attributeMapping
                .ToTable("Wilcommerce_ProductAttributes")
                .HasOne(pa => pa.Attribute)
                .WithMany();

            attributeMapping
                .Property(pa => pa._Value)
                .HasColumnName("Value");

            attributeMapping.Ignore(pa => pa.Value);

            return modelBuilder;
        }
    }
}
