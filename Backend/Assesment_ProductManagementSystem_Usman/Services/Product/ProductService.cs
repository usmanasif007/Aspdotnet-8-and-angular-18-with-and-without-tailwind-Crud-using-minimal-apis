using Assesment_ProductManagementSystem_Usman.CommonMethod;
using Assesment_ProductManagementSystem_Usman.OutputData;
using Assesment_ProductManagementSystem_Usman.Services.Product.DTOs;
using Assesment_ProductManagementSystem_Usman.UnitOfWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assesment_ProductManagementSystem_Usman.Services.Product
{
    public class ProductService(IMapper mapper, IUnitOfWork unitOfWork) : IProductService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private string entity = "Product";

        public async Task<OutputDTO<List<ProductDTO>>> GetAll(ProductFilterDTO input)
        {
            string sortBy = string.IsNullOrEmpty(input.SortBy) ? "Id" : input.SortBy;
            string sortDirection = string.IsNullOrEmpty(input.SortDirection) ? "desc" : input.SortDirection;

            var filter = PredicateBuilder.True<Assesment_ProductManagementSystem_Usman.Entities.Product.Product>();

            if (!string.IsNullOrEmpty(input.Search))
                filter = filter.And(x => x.Name.Contains(input.Search));

            var productList = _unitOfWork.ProductRepo.AsQueryable()
                                    .Where(filter).
                                    Select(x => new ProductDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Price = x.Price,
                                        CreatedDate = x.CreatedDate,
                                    });

            var totalCount = productList.Count();
            var list = new List<ProductDTO>();

            if (totalCount is 0)
                return OutputHandler.Handler((int)ResponseType.NOT_EXIST, list, entity);

            if (input.IsPagination)
                list = await productList.ApplySorting(sortBy, sortDirection).ToPaggedListAsync(input.PageNo, input.Size);
            else
                list = productList.ApplySorting(sortBy, sortDirection).ToList();

                return OutputHandler.Handler((int)ResponseType.GET_ALL, list, entity, totalCount);
        }

        public async Task<OutputDTO<bool>> Save(ProductDTO input)
        {
            var existRecord = _unitOfWork.ProductRepo.GetAsync(x => x.Name == input.Name && x.Id != input.Id);

            if (existRecord is not null)
                return OutputHandler.Handler((int)ResponseType.EXIST, false, entity);

            if (input.Id is 0)
            {
                var mapper = _mapper.Map<Assesment_ProductManagementSystem_Usman.Entities.Product.Product>(input);

                await _unitOfWork.ProductRepo.AddAsync(mapper);
                await _unitOfWork.SaveAsync();

                return OutputHandler.Handler((int)ResponseType.CREATE, true, entity);
            }
            else if (input.Id > 0)
            {
                var product = await _unitOfWork.ProductRepo.GetAsync(x => x.Id == input.Id);

                var mapper = _mapper.Map(input, product);

                await _unitOfWork.ProductRepo.UpdateAsync(mapper);
                await _unitOfWork.SaveAsync();

                return OutputHandler.Handler((int)ResponseType.UPDATE, true, entity);
            }

            return OutputHandler.Handler((int)ResponseType.INVALID_REQUEST, false, entity);
        }
        public async Task<OutputDTO<bool>> Delete(ProductDTO input)
        {
            var Record = await _unitOfWork.ProductRepo.GetAsync(x => x.Id == input.Id);

            _unitOfWork.ProductRepo.Remove(Record);

            return OutputHandler.Handler((int)ResponseType.DELETE, true, entity);
        }

    }
}
