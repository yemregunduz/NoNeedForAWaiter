using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDetailDal:IEntityRepository<OrderDetail>
    {
        public List<OrderDetailDto> GetAllOrderDetailDto(Expression<Func<OrderDetailDto, bool>> filter = null);
    }
}
