using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class OrderTableDto:IDto
    {
        public int  Id { get; set; }
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int TableNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        public int OrderStatus { get; set; }
        public string RestaurantName { get; set; }
    }
}
