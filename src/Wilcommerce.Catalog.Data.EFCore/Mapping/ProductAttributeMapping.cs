using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="ProductAttribute"/> class
    /// </summary>
    public static class ProductAttributeMapping
    {
        /// <summary>
        /// Extension method. Map the custom attribute class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapProductAttributes(this ModelBuilder modelBuilder)
        {
            var attributeMapping = modelBuilder.Entity<ProductAttribute>();

            attributeMapping
                .ToTable("Wilcommerce_ProductAttributes")
                .HasKey(pa => pa.Id);

            attributeMapping
                .Property(pa => pa.Id)
                .ValueGeneratedNever();

            attributeMapping
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
