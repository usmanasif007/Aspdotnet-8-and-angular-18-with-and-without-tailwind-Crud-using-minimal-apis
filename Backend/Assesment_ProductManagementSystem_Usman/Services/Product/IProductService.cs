using Assesment_ProductManagementSystem_Usman.OutputData;
using Assesment_ProductManagementSystem_Usman.Services.Product.DTOs;

namespace Assesment_ProductManagementSystem_Usman.Services.Product
{
    public interface IProductService
    {
        Task<OutputDTO<List<ProductDTO>>> GetAll(ProductFilterDTO input);
        Task<OutputDTO<bool>> Save(ProductDTO input);
    }
}
