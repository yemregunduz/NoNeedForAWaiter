using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpPost("add")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Add(orderDetail);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Delete(orderDetail);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Update(orderDetail);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallorderdetailsbyorderid")]
        public IActionResult GetAllOrderDetailsByOrderId(int orderId)
        {
            var result = _orderDetailService.GetAllOrderDetailsByOrderId(orderId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
