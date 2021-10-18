using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Table : IEntity
    {
        public int Id { get; set; }
        public int TableNo { get; set; }
        public int RestaurantId { get; set; }
    }
}
