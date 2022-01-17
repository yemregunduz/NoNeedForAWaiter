using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class QrCode:IEntity
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public byte[] QrCodeImagePath { get; set; }
        public string RouterLink { get; set; }
    }
}
