using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class CategoryMapping
    {
        public static ModelBuilder MapCategory(this ModelBuilder modelBuilder)
        {
            var categoryMapping = modelBuilder.Entity<Category>();

            categoryMapping
                .ToTable("Wilcommerce_Categories")
                .HasIndex(c => c.Code).IsUnique();

            categoryMapping
                .HasIndex(c => c.Url).IsUnique();

            categoryMapping
                .HasOne(c => c.Seo);

            categoryMapping.Property(c => c.Children)
                .HasField("_children");

            categoryMapping
                .Metadata
                .FindNavigation(nameof(Category.Children))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            categoryMapping
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent);

            categoryMapping.Property(c => c.Products)
                .HasField("_products");

            categoryMapping
                .Metadata
                .FindNavigation(nameof(Category.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            categoryMapping
                .HasMany(c => c.Products)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId);

            return modelBuilder;
        }
    }
}
