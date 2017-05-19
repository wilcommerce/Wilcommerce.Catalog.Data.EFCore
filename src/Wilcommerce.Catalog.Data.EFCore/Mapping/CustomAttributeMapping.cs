using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class CustomAttributeMapping
    {
        public static ModelBuilder MapCustomAttributes(this ModelBuilder modelBuilder)
        {
            var attributeMapping = modelBuilder.Entity<CustomAttribute>();

            attributeMapping
                .ToTable("Wilcommerce_CustomAttributes")
                .Property(a => a._Values)
                .HasColumnName("Values");

            attributeMapping
                .Ignore(a => a.Values);

            return modelBuilder;
        }
    }
}
