using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NoNeedForAWaiterContext>, IProductDal
    {
        public List<ProductDetailDto> GetAllProductDetailsDto(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from p in context.PRODUCTS
                             join pi in context.PRODUCTIMAGES
                             on p.Id equals pi.ProductId into gj1
                             from pi in gj1.DefaultIfEmpty()
                             join c in context.CATEGORIES
                             on p.CategoryId equals c.Id
                             orderby p.CategoryId ascending
                             select new ProductDetailDto
                             
                             {
                                 Id = p.Id,
                                 CategoryId = c.Id,
                                 ProductDescription = p.ProductDescription,
                                 ProductImageId = pi.Id,
                                 ProductImagePath = pi.ProductImagePath,
                                 ProductName = p.ProductName,
                                 Stock = p.Stock,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice,
                                 RestaurantId=p.RestaurantId
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
