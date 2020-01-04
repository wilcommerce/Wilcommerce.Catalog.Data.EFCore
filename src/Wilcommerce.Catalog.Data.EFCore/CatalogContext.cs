using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Data.EFCore.Mapping;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore
{
    /// <summary>
    /// Defines the Entity Framework context for the catalog package
    /// </summary>
    public class CatalogContext : DbContext
    {
        /// <summary>
        /// Get or set the list of brands
        /// </summary>
        public virtual DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Get or set the list of categories
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Get or set the list of custom attributes
        /// </summary>
        public virtual DbSet<CustomAttribute> CustomAttributes { get; set; }

        /// <summary>
        /// Get or set the list of products
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Get or set the list of product attributes
        /// </summary>
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

        /// <summary>
        /// Get or set the list of product categories
        /// </summary>
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Get or set the list of product images
        /// </summary>
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        /// <summary>
        /// Get or set the list of product reviews
        /// </summary>
        public virtual DbSet<ProductReview> ProductReviews { get; set; }

        /// <summary>
        /// Get or set the list of tier prices
        /// </summary>
        public virtual DbSet<TierPrice> TierPrices { get; set; }

        /// <summary>
        /// Construct the catalog context
        /// </summary>
        /// <param name="options">The context options</param>
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Override the <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// </summary>
        /// <param name="optionsBuilder">The options builder instance</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        /// <summary>
        /// Override the <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// </summary>
        /// <param name="modelBuilder">The model builder instance</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .MapBrand()
                .MapCategory()
                .MapProducts()
                .MapCustomAttributes()
                .MapProductAttributes()
                .MapTierPrices()
                .MapProductCategories()
                .MapProductReviews()
                .MapProductImages();

            base.OnModelCreating(modelBuilder);
        }
    }
}
