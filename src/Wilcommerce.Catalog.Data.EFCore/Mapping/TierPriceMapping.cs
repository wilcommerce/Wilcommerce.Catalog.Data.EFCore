using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class TierPriceMapping
    {
        public static ModelBuilder MapTierPrices(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TierPrice>()
                .ToTable("Wilcommerce_TierPrices")
                .HasOne(t => t.Price);

            return modelBuilder;
        }
    }
}
