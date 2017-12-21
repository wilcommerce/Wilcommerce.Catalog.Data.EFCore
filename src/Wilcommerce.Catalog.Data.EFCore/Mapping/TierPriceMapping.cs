using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="TierPrice"/> class
    /// </summary>
    public static class TierPriceMapping
    {
        /// <summary>
        /// Extension method. Map the tier price class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapTierPrices(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TierPrice>()
                .ToTable("Wilcommerce_TierPrices")
                .OwnsOne(t => t.Price);

            return modelBuilder;
        }
    }
}
