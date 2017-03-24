using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore
{
    public class CatalogContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<CatalogSettings> CatalogSettings { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CustomAttribute> CustomAttributes { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<ProductReview> ProductReviews { get; set; }

        public virtual DbSet<TierPrice> TierPrices { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
