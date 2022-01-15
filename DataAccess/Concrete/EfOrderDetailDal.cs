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
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, NoNeedForAWaiterContext>, IOrderDetailDal
    {
        public List<OrderDetailDto> GetAllOrderDetailDto(Expression<Func<OrderDetailDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from od in context.ORDERDETAILS
                             join o in context.ORDERS
                             on od.OrderId equals o.Id

                             join p in context.PRODUCTS
                             on od.ProductId equals p.Id

                             join pi in context.PRODUCTIMAGES
                             on p.Id equals pi.ProductId into gj1
                             from pi in gj1.DefaultIfEmpty()

                             orderby od.LineTotal descending
                             select new OrderDetailDto
                             {
                                 OrderDetailId = od.Id,
                                 OrderId = o.Id,
                                 Quantity = od.Quantity,
                                 LineTotal = od.LineTotal,
                                 TableId = o.TableId,
                                 OrderDate = o.OrderDate,
                                 CategoryId = p.CategoryId,
                                 OrderStatus = o.OrderStatus,
                                 ProductDescription = p.ProductDescription,
                                 ProductId = p.Id,
                                 ProductImagePath = pi.ProductImagePath,
                                 ProductName = p.ProductName,
                                 RestaurantId = p.RestaurantId,
                                 Stock = p.Stock,
                                 UnitPrice = p.UnitPrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
