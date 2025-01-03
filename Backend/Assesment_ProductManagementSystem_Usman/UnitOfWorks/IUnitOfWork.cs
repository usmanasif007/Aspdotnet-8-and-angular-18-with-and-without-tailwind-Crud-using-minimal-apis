using Assesment_ProductManagementSystem_Usman.Entities.Product;
using Assesment_ProductManagementSystem_Usman.GenericRepository;

namespace Assesment_ProductManagementSystem_Usman.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepo { get; }
        Task<object> SaveAsync();
    }
}
