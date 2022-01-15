using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public decimal OrderAmount { get; set; }
    }
}
