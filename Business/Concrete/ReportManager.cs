using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public IDataResult<List<BestSellingProductDetailDto>> GetTop10BestSellingProduct()
        {
            return new SuccessDataResult<List<BestSellingProductDetailDto>>(_reportDal.GetAllTopSellingProducts());
        }
    }
}
