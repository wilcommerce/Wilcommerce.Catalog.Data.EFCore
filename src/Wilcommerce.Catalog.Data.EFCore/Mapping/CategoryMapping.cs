using Microsoft.EntityFrameworkCore;
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
                .OwnsOne(c => c.Seo);

            categoryMapping
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent);

            categoryMapping
                .Metadata
                .FindNavigation(nameof(Category.Children))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            categoryMapping
                .HasMany(c => c.Products)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId);

            categoryMapping
                .Metadata
                .FindNavigation(nameof(Category.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            return modelBuilder;
        }
    }
}
