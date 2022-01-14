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
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallordertablesdtobyrestaurantid")]
        public IActionResult GetAllOrderTablesDtoByRestaurantId(int restaurantId)
        {
            var result = _orderService.GetAllOrderTablesDtoByRestaurantId(restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallordertablesdtobytableid")]
        public IActionResult GetAllOrderTablesDtoByTableId(int tableId)
        {
            var result = _orderService.GetAllOrderTablesDtoByTableId(tableId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallordertablesdtobyrestaurantidandorderstatus")]
        public IActionResult GetAllOrderTablesDtoByRestaurantIdAndOrderStatus(int restaurantId,bool orderStatus)
        {
            var result = _orderService.GetAllOrderTablesDtoByRestaurantIdAndOrderStatus(restaurantId, orderStatus);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
