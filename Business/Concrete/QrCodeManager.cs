using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
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
            qrCode = QrCodeHelper.CreateQrCode(qrCode);
            var result = BusinessRules.Run(CheckIfQrCodeLimitExceeded(qrCode.TableId));
            if (result!=null)
            {
                return result;
            }
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
        //businesRules

        private IResult CheckIfQrCodeLimitExceeded(int tableId)
        {
            var countOfUserImages = GetAllQrCodeTableDtosByTableId(tableId).Data.Count;
            if (countOfUserImages >= 12)
            {
                return new ErrorResult(Messages.QrCodeLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
