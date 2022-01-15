using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        [ValidationAspect(typeof(OrderDetailValidator), Priority = 1)]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult(Messages.OrderDetailCreated);
        }
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult(Messages.OrderDetailDeleted);
        }
        [CacheAspect]
        public IDataResult<List<OrderDetailDto>> GetAllOrderDetailDtosByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetAllOrderDetailDto(od => od.OrderId == orderId), Messages.OrderDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<OrderDetail>> GetAllOrderDetailsByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(od => od.OrderId == orderId));
        }
        [ValidationAspect(typeof(OrderDetailValidator), Priority = 1)]
        [CacheRemoveAspect("IOrderDetailService.Get")]
        public IResult Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult(Messages.OrderDetailUpdated);
        }
    }
}
