using Assesment_ProductManagementSystem_Usman.Entities.Product;
using Assesment_ProductManagementSystem_Usman.Services.Product.DTOs;
using AutoMapper;

namespace Assesment_ProductManagementSystem_Usman.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDTO, Product>();
    }
}
