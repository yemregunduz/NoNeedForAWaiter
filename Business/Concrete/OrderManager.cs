using Business.Abstract;
using Business.Constants;
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
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<OrderTableDto>>(_orderDal.GetAllOrderTablesDto(o => o.RestaurantId == restaurantId),Messages.OrdersListed);
        }

        public IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByTableId(int tableId)
        {
            return new SuccessDataResult<List<OrderTableDto>>(_orderDal.GetAllOrderTablesDto(o => o.TableId == tableId),Messages.OrdersListedByTableId);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
