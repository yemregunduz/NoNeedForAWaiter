using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class OrderTableDto:IDto
    {
        public int  OrderId { get; set; }
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int TableNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        public bool OrderStatus { get; set; }
        public string RestaurantName { get; set; }
    }
}
