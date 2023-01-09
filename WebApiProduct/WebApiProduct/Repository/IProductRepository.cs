using Microsoft.Extensions.Hosting;
using WebApiProduct.Dtos;

namespace WebApiProduct.Repository
{
    public interface IProductRepository
    {
        //Insert(POST)
        //Update(PUT)
        //GetById(GET)
        Task<ProductDto> InsertProduct(ProductDto productDto);
        Task<ProductDto> UpdateProduct(ProductDto productDto);
        Task<ProductDto> GetProductById(int productId);
        

    }
}
