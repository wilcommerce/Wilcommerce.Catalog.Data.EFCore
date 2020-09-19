using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="CustomAttribute"/> class
    /// </summary>
    public static class CustomAttributeMapping
    {
        /// <summary>
        /// Extension method. Map the custom attribute class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapCustomAttributes(this ModelBuilder modelBuilder)
        {
            var attributeMapping = modelBuilder.Entity<CustomAttribute>();

            attributeMapping
                .ToTable("Wilcommerce_CustomAttributes")
                .HasKey(a => a.Id);

            attributeMapping
                .Property(a => a.Id)
                .ValueGeneratedNever();

            attributeMapping
                .Property(a => a._Values)
                .HasColumnName("Values");

            attributeMapping
                .Ignore(a => a.Values);

            return modelBuilder;
        }
    }
}
