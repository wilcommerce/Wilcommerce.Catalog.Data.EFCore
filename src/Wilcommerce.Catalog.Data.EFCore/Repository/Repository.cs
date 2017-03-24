using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Repository;

namespace Wilcommerce.Catalog.Data.EFCore.Repository
{
    public class Repository : IRepository
    {
        protected CatalogContext _context;

        public Repository(CatalogContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }

        public void Add<TModel>(TModel model) where TModel : class, Core.Infrastructure.IAggregateRoot
        {
            try
            {
                _context.Set<TModel>().Add(model);
            }
            catch 
            {
                throw;
            }
        }

        public TModel GetByKey<TModel>(Guid key) where TModel : class, Core.Infrastructure.IAggregateRoot
        {
            try
            {
                return _context.Find<TModel>(key);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> GetByKeyAsync<TModel>(Guid key) where TModel : class, Core.Infrastructure.IAggregateRoot
        {
            try
            {
                var model = await _context.FindAsync<TModel>(key);
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}
