﻿namespace WebApiProduct.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public string? StatusName { get; set; }


    }
}
