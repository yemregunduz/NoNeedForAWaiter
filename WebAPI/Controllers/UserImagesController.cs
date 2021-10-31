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
    public class UserImagesController : ControllerBase
    {
        IUserImageService _userImageService;
        public UserImagesController(IUserImageService userImageService)
        {
            _userImageService = userImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("userImage"))] IFormFile file, [FromForm] UserImage userImage)
        {
            var result = _userImageService.Add(file, userImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("id"))] int Id)
        {
            var userImage = _userImageService.Get(Id).Data;
            var result = _userImageService.Delete(userImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("userImage"))] IFormFile file,[FromForm(Name =("imageId"))] int Id)
        {
            var userImage = _userImageService.Get(Id).Data;
            var result = _userImageService.Update(file, userImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalluserimagesbyuserid")]
        public IActionResult GetAllUserImagesByUserId(int userId)
        {
            var result = _userImageService.GetAllUserImagesByUserId(userId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
