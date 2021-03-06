using Business.Abstract;
using Core.Extensions;
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
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;
        IHttpContextAccessor _httpContextAccessor;
        public ProductImagesController(IProductImageService productImageService, IHttpContextAccessor httpContextAccessor)
        {
            _productImageService = productImageService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("productImage"))] IFormFile file, [FromForm] ProductImage productImage)
        {
            var userClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            var result = _productImageService.Add(file, productImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name =("imageId"))] int imageId)
        {
            var userImage = _productImageService.GetProductImageByImageId(imageId).Data;
            var result = _productImageService.Delete(userImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("productImage"))] IFormFile file, [FromForm(Name = ("imageId"))] int imageId)
        {
            var userImage = _productImageService.GetProductImageByImageId(imageId).Data;
            var result = _productImageService.Update(file, userImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallproductimagesbyproductid")]
        public IActionResult GetAllProductImagesByProductId(int productId)
        {
            var result = _productImageService.GetAllProductImagesByProductId(productId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
