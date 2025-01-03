using Assesment_ProductManagementSystem_Usman.Context;
using Assesment_ProductManagementSystem_Usman.GenericRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System;
using Assesment_ProductManagementSystem_Usman.Entities.Product;

namespace Assesment_ProductManagementSystem_Usman.UnitOfWorks
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed = false;
        private readonly MainContext _context;
        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        private IRepository<Product> _productRepo;
       

        public IRepository<Product> ProductRepo
        {
            get
            {
                return _productRepo ??
                    (_productRepo = new Repository<Product>(_context));
            }
        }

        public async Task<object> SaveAsync()
        {
            var res = await _context.SaveChangesAsync();
            return res;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
