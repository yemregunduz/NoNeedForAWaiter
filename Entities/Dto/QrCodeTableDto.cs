using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class QrCodeTableDto:IDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public byte[] QrCodeImagePath { get; set; }
        public string RouterLink { get; set; }
        public int RestaurantId { get; set; }
        public int TableNo { get; set; }
    }
}
