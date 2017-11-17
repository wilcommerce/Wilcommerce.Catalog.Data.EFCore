using System.Linq;
using Wilcommerce.Catalog.Models;
using Wilcommerce.Catalog.ReadModels;

namespace Wilcommerce.Catalog.Data.EFCore.ReadModels
{
    /// <summary>
    /// Implementation of <see cref="ICatalogDatabase"/> 
    /// </summary>
    public class CatalogDatabase : ICatalogDatabase
    {
        /// <summary>
        /// The DbContext instance
        /// </summary>
        protected CatalogContext _context;

        public CatalogDatabase(CatalogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the list of brands
        /// </summary>
        public IQueryable<Brand> Brands => _context.Brands;

        /// <summary>
        /// Get the list of categories
        /// </summary>
        public IQueryable<Category> Categories => _context.Categories;

        /// <summary>
        /// Get the list of custom attributes
        /// </summary>
        public IQueryable<CustomAttribute> CustomAttributes => _context.CustomAttributes;

        /// <summary>
        /// Get the list of product attributes
        /// </summary>
        public IQueryable<ProductAttribute> ProductAttributes => _context.ProductAttributes;

        /// <summary>
        /// Get the list of product images
        /// </summary>
        public IQueryable<ProductImage> ProductImages => _context.ProductImages;

        /// <summary>
        /// Get the list of product reviews
        /// </summary>
        public IQueryable<ProductReview> ProductReviews => _context.ProductReviews;

        /// <summary>
        /// Get the list of products
        /// </summary>
        public IQueryable<Product> Products => _context.Products;

        /// <summary>
        /// Get the list of catalog settings
        /// </summary>
        public IQueryable<CatalogSettings> Settings => _context.CatalogSettings;

        /// <summary>
        /// Get the list of tier prices
        /// </summary>
        public IQueryable<TierPrice> TierPrices => _context.TierPrices;

        /// <summary>
        /// Get the product categories
        /// </summary>
        public IQueryable<ProductCategory> ProductCategories => _context.ProductCategories;
    }
}
