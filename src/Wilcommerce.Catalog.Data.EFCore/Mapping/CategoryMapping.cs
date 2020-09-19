using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="Category"/> class
    /// </summary>
    public static class CategoryMapping
    {
        /// <summary>
        /// Extension method. Map the category class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapCategory(this ModelBuilder modelBuilder)
        {
            var categoryMapping = modelBuilder.Entity<Category>();

            categoryMapping
                .ToTable("Wilcommerce_Categories")
                .HasKey(c => c.Id);

            categoryMapping
                .Property(c => c.Id)
                .ValueGeneratedNever();

            categoryMapping
                .HasIndex(c => c.Code).IsUnique();

            categoryMapping
                .HasIndex(c => c.Url).IsUnique();

            categoryMapping
                .OwnsOne(c => c.Seo);

            categoryMapping
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent);

            categoryMapping
                .HasMany(c => c.Products)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId);


            return modelBuilder;
        }
    }
}
