using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProduct.Dtos;
using WebApiProduct.Repository;

namespace WebApiProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private ResponseDto responseDto;
        public ProductController(IProductRepository productRepository) 
        { 
            this.productRepository = productRepository; 
            this.responseDto = new ResponseDto();   
        
        }

        [HttpPost]
        public async Task<object> Post(ProductDto product)
        {
            try
            {
                ProductDto result = await productRepository.InsertProduct(product) ;
                responseDto.Result = result;

            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };

            }
            return responseDto;

        }

        [HttpPut]
        public async Task<object> Put(ProductDto product)
        {
            try
            {
                ProductDto result = await productRepository.UpdateProduct(product);
                responseDto.Result = result;

            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };

            }
            return responseDto;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto product = await productRepository.GetProductById(id);
                responseDto.Result = product;
            }
            catch (Exception ex)
            {
                responseDto.IsSucceed = false;
                responseDto.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return responseDto;
        }



    }
}
