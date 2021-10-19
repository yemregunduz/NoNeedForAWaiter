using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Restaurant:IEntity
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        
        public string TaxNumber { get; set; }
    }
}
