using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IReportDal
    {
        List<BestSellingProductDetailDto> GetAllTopSellingProducts(Expression<Func<BestSellingProductDetailDto, bool>> filter = null);
    }
}
