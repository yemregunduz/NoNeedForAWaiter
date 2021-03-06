using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> Add (Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
        IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByRestaurantIdAndOrderStatus(int restaurantId, int orderStatus);
        IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByRestaurantId(int restaurantId);
        IDataResult<List<OrderTableDto>> GetAllOrderTablesDtoByTableId(int tableId);
    }
}
