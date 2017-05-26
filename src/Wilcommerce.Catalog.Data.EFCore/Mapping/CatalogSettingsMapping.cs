using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    public static class CatalogSettingsMapping
    {
        public static ModelBuilder MapCatalogSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogSettings>()
                .ToTable("Wilcommerce_CatalogSettings");

            return modelBuilder;
        }
    }
}
