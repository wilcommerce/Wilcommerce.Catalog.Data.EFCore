using System.Linq;
using Wilcommerce.Catalog.Models;
using Wilcommerce.Catalog.ReadModels;

namespace Wilcommerce.Catalog.Data.EFCore.ReadModels
{
    public class CatalogDatabase : ICatalogDatabase
    {
        protected CatalogContext _context;

        public CatalogDatabase(CatalogContext context)
        {
            _context = context;
        }

        public IQueryable<Brand> Brands => _context.Brands;

        public IQueryable<Category> Categories => _context.Categories;

        public IQueryable<CustomAttribute> CustomAttributes => _context.CustomAttributes;

        public IQueryable<ProductAttribute> ProductAttributes => _context.ProductAttributes;

        public IQueryable<ProductImage> ProductImages => _context.ProductImages;

        public IQueryable<ProductReview> ProductReviews => _context.ProductReviews;

        public IQueryable<Product> Products => _context.Products;

        public IQueryable<CatalogSettings> Settings => _context.CatalogSettings;

        public IQueryable<TierPrice> TierPrices => _context.TierPrices;
    }
}
