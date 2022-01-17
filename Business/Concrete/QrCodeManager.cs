using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class QrCodeManager : IQrCodeService
    {
        IQrCodeDal _qrCodeDal;
        public QrCodeManager(IQrCodeDal qrCodeDal)
        {
            _qrCodeDal = qrCodeDal;
        }
        public IResult Add(QrCode qrCode)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeScale = 1;
            Bitmap qrCodeToCreate = qrCodeEncoder.Encode(qrCode.RouterLink);
            MemoryStream memoryStream = new MemoryStream();
            qrCodeToCreate.Save(memoryStream, ImageFormat.Jpeg);
            qrCode.QrCodeImagePath = memoryStream.ToArray();
            _qrCodeDal.Add(qrCode);
            return new SuccessResult(Messages.QrCodeCreated);
        }

        public IResult Delete(QrCode qrCode)
        {
            _qrCodeDal.Delete(qrCode);
            return new SuccessResult(Messages.QrCodeDeleted);
        }

        public IDataResult<List<QrCodeTableDto>> GetAllQrCodeTableDtosByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<QrCodeTableDto>>(_qrCodeDal.GetAllQrCodeTableDtos(q => q.RestaurantId == restaurantId),Messages.QrCodeListedByRestaurantId);
        }

        public IDataResult<List<QrCodeTableDto>> GetAllQrCodeTableDtosByTableId(int tableId)
        {
            return new SuccessDataResult<List<QrCodeTableDto>>(_qrCodeDal.GetAllQrCodeTableDtos(q => q.TableId == tableId),Messages.QrCodeListedByTableId);
        }

        public IResult Update(QrCode qrCode)
        {
            _qrCodeDal.Update(qrCode);
            return new SuccessResult(Messages.QrCodeUpdated);
        }
    }
}
