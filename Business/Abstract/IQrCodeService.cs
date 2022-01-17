using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IQrCodeService
    {
        public IResult Add(QrCode qrCode);
        public IResult Delete(QrCode qrCode);
        public IResult Update(QrCode qrCode);
        public IDataResult<List<QrCodeTableDto>> GetAllQrCodeTableDtosByRestaurantId(int restaurantId);
        public IDataResult<List<QrCodeTableDto>> GetAllQrCodeTableDtosByTableId(int tableId);
    }
}
