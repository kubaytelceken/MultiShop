using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailServiceAsync();
        Task CreateProductDetailServiceAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailServiceAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailServiceAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailServiceAsync(string id);
    }
}
