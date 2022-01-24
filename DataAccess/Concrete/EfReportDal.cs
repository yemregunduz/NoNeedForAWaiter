using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfReportDal : IReportDal
    {
        public List<BestSellingProductDetailDto> GetAllTopSellingProducts(Expression<Func<BestSellingProductDetailDto, bool>> filter = null )
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from o in context.ORDERS

                             join od in context.ORDERDETAILS
                             on o.Id equals od.OrderId into gj
                             from od in gj.DefaultIfEmpty()

                             join p in context.PRODUCTS
                             on od.ProductId equals p.Id into gj1
                             from p in gj1.DefaultIfEmpty()

                             join c in context.CATEGORIES
                             on p.CategoryId equals c.Id into gj2
                             from c in gj2.DefaultIfEmpty()

                             where o.OrderStatus == 2

                             group new { o, od, c, p } by new { p.Id, p.ProductName, p.CategoryId,c.CategoryName } into groupped
                             

                             select new BestSellingProductDetailDto
                             {

                                 ProductName = groupped.Key.ProductName,
                                 CategoryId = groupped.Key.CategoryId,
                                 CategoryName = groupped.Key.CategoryName,
                                 Quantity = groupped.Sum(g => g.od.Quantity),
                                 ProductId = groupped.Key.Id,
                                 TotalSales = groupped.Sum(p=>p.od.Quantity*p.p.UnitPrice),

                             };
                return filter == null ? result.OrderByDescending(bs=>bs.Quantity).Take(10).ToList() : result.Where(filter).ToList();
                
                             


                             
            }
        }
    }
}
