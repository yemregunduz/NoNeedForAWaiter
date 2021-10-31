using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProductImage:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductImagePath { get; set; }
        public DateTime Date { get; set; }
        public ProductImage()
        {
            Date = DateTime.Now;
        }
    }
}
