using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiProduct.Dtos;
using WebApiProduct.Models;

namespace WebApiProduct.Test.Services
{
    public class ProductServicesTest
    {
        private Product product;
        private ProductDto productDto;
        private IMapper mapper;
        [SetUp]
        public void Setup()
        {
            mapper = Substitute.For<IMapper>();
            product = new Product()
            {
                ProductId=1,
                Name= "Vino Tabernero",
                Status=true,
                Stock=10,
                Description= "Vino Tinto Peruano",
                Price=20
                //[Name] [varchar](200) NULL,
                //[Status] [bit] NOT NULL,
                //[Stock] [int] NOT NULL,
                //[Description] [varchar](200) NULL,
                //[Price] [decimal](18, 2) NOT NULL
            };
            productDto = new ProductDto()
            {
                Name = "Vino Tabernero",
                Status = true,
                Stock = 10,
                Description = "Vino Tinto Peruano",
                Price = 20

            };
        }

        //private IServiceProvider CrateContext(string nameDB)
        //{
        //    var services = new ServiceCollection();

        //    //services.AddDbContext<ProductDto>()
            
        //}

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
