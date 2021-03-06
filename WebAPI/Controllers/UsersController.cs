using Business.Abstract;
using Core.Entities.Concrete;
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
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
            
        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallusersbyrestaurantidandstatus")]
        public IActionResult GetAllUsersByRestaurantIdAndStatus(int restaurantId, bool status)
        {
            var result = _userService.GetAllUsersByRestaurantIdAndStatus(restaurantId, status);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserdetaildtobyuserid")]
        public IActionResult GetUserDetailDtoByUserId(int userId)
        {
            var result = _userService.GetUserDetailDtoByUserId(userId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallusersbyfiltertext")]
        public IActionResult GetAllUserByFilterText(string filterText)
        {
            var result = _userService.GetAllUsersByFilterText(filterText);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
