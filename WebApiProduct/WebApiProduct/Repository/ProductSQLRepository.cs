using WebApiProduct.DbContexts;
using WebApiProduct.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiProduct.Models;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace WebApiProduct.Repository
{
    public class ProductSQLRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;
        private IMapper mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductSQLRepository(AppDbContext dbContext, IMapper mapper, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            _memoryCache = memoryCache;
            
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            //throw new NotImplementedException();
            var url = "https://63b9dda54482143a3f1d4816.mockapi.io/Discounts/" + productId  ;
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var discount = 0;
            if (response.IsSuccessStatusCode)
            { 
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductDiscountDto>(content);
                if (result == null)
                    discount= 0;
                else 
                    discount= result.PercentageDiscount;
            }
            else
            {
                discount = 0;
            };

            var product = await this.dbContext.products
            .Where(product => product.ProductId == productId)
            .FirstOrDefaultAsync();
            var productdto = mapper.Map<ProductDto>(product);
            var _cache = new Cache.Cache(_memoryCache);
            _cache.SetCache();
            //productdto.Status = (string)_memoryCache.Get(product.Status);
            productdto.StatusName = (string)_memoryCache.Get(productdto.Status);
            productdto.Discount = discount;
            productdto.FinalPrice = productdto.Price*(100-discount)/100; //Price * (100 - Discount) / 100
            return productdto;
        }

        public async Task<ProductDto> InsertProduct(ProductDto productDto)
        {
            //throw new NotImplementedException();
            var product = mapper.Map<Product>(productDto);
            this.dbContext.products.Add(product);
            await this.dbContext.SaveChangesAsync();
            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            //throw new NotImplementedException();
            var product = mapper.Map<Product>(productDto);
            this.dbContext.products.Update(product);
            await this.dbContext.SaveChangesAsync();
            return mapper.Map<ProductDto>(product);

        }
    }
}
