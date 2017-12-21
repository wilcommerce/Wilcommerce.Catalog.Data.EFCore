using Microsoft.EntityFrameworkCore;
using Wilcommerce.Catalog.Models;

namespace Wilcommerce.Catalog.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="CatalogSettings"/> class
    /// </summary>
    public static class CatalogSettingsMapping
    {
        /// <summary>
        /// Extension method. Map the catalog settings class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapCatalogSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogSettings>()
                .ToTable("Wilcommerce_CatalogSettings");

            return modelBuilder;
        }
    }
}
