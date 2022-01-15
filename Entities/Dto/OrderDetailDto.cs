using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class OrderDetailDto:IDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public decimal LineTotal { get; set; }
        public int TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImagePath { get; set; }





    }
}
