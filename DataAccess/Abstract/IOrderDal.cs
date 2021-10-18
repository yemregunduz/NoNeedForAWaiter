using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        List<OrderTableDto> GetAllOrderTablesDto(Expression<Func<OrderTableDto, bool>> filter = null);
    }
}
