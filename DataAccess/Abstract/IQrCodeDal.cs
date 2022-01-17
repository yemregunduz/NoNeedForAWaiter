using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IQrCodeDal:IEntityRepository<QrCode>
    {
        List<QrCodeTableDto> GetAllQrCodeTableDtos(Expression<Func<QrCodeTableDto, bool>> filter = null);
    }
}
