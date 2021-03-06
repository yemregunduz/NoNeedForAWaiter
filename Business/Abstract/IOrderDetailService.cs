using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IResult Add(OrderDetail orderDetail);
        IResult Delete(OrderDetail orderDetail);
        IResult Update(OrderDetail orderDetail);
        IDataResult<List<OrderDetail>> GetAllOrderDetailsByOrderId(int orderId);
        IDataResult<List<OrderDetailDto>> GetAllOrderDetailDtosByOrderId(int orderId);

    }
}
