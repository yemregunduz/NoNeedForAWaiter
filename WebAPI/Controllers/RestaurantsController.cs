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
    public class RestaurantsController : ControllerBase
    {
        IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpPost("add")]
        public IActionResult Add(Restaurant restaurant)
        {
            var result = _restaurantService.Add(restaurant);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Restaurant restaurant)
        {
            var result = _restaurantService.Delete(restaurant);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Restaurant restaurant)
        {
            var result = _restaurantService.Update(restaurant);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _restaurantService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
