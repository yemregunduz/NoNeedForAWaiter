using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfQrCodeDal : EfEntityRepositoryBase<QrCode, NoNeedForAWaiterContext>, IQrCodeDal
    {
        public List<QrCodeTableDto> GetAllQrCodeTableDtos(Expression<Func<QrCodeTableDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from q in context.QRCODES
                             join t in context.TABLES_
                             on q.TableId equals t.Id

                             select new QrCodeTableDto
                             {
                                 Id = q.Id,
                                 TableId = q.TableId,
                                 QrCodeImagePath = q.QrCodeImagePath,
                                 RestaurantId = t.RestaurantId,
                                 RouterLink = q.RouterLink,
                                 TableNo = t.TableNo
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
