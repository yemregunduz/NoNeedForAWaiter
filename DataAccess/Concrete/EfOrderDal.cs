using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NoNeedForAWaiterContext>, IOrderDal
    {
        public List<OrderTableDto> GetAllOrderTablesDto(Expression<Func<OrderTableDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from o in context.ORDERS
                             join t in context.TABLES_
                             on o.TableId equals t.Id
                             join r in context.RESTAURANTS
                             on t.RestaurantId equals r.Id
                             orderby o.OrderDate descending 
                             select new OrderTableDto
                             {
                                 OrderId = o.Id,
                                 TableId = t.Id,
                                 RestaurantId = r.Id,
                                 OrderAmount = o.OrderAmount,
                                 OrderDate = o.OrderDate,
                                 OrderStatus = o.OrderStatus,
                                 RestaurantName = r.RestaurantName,
                                 TableNo = t.TableNo
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
