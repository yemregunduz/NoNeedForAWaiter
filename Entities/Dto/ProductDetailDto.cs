using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ProductDetailDto:IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductImageId { get; set; }
        public string ProductImagePath { get; set; }
    }
}
