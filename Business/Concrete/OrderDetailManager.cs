using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public IResult Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult(Messages.OrderDetailCreated);
        }

        public IResult Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult(Messages.OrderDetailDeleted);
        }

        public IDataResult<List<OrderDetail>> GetAllOrderDetailsByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(od => od.OrderId == orderId));
        }

        public IResult Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult(Messages.OrderDetailUpdated);
        }
    }
}
