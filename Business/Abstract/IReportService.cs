using Core.Utilities.Results.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReportService
    {
        IDataResult<List<BestSellingProductDetailDto>> GetTop10BestSellingProduct();
    }
}
