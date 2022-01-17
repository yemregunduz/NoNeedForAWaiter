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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        [CacheRemoveAspect("IOrderService.Get")]
        public IDataResult<Order> Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessDataResult<Order>(order,Messages.OrderAdded);
        }
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }
        [CacheAspect]
        public IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<OrderTableDto>>(_orderDal.GetAllOrderTablesDto(o => o.RestaurantId == restaurantId),Messages.OrdersListed);
        }
        [CacheAspect]
        public IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByTableId(int tableId)
        {
            return new SuccessDataResult<List<OrderTableDto>>(_orderDal.GetAllOrderTablesDto(o => o.TableId == tableId),Messages.OrdersListedByTableId);
        }
        public IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByRestaurantIdAndOrderStatus(int restaurantId,int orderStatus)
        {
            return new SuccessDataResult<List<OrderTableDto>>(_orderDal.GetAllOrderTablesDto(o => o.RestaurantId == restaurantId && o.OrderStatus!=orderStatus));
        }
        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
