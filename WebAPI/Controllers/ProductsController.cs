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
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallproductsbycategoryidandrestaurantid")]
        public IActionResult GetAllProductsByCategoryIdAndRestarauntId(int categoryId,int restaurantId)
        {
            var result = _productService.GetAllProductsByCategoryIdAndRestaurantId(categoryId, restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallproductsbyrestaurantid")]
        public IActionResult GetAllProductsByRestaurantId(int restaurantId)
        {
            var result = _productService.GetAllProductsByRestaurantId(restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallproductdetailsdtobyrestaurantid")]
        public IActionResult GetAllProductDetailsDtoByRestaurantId(int restaurantId)
        {
            var result = _productService.GetAllProductDetailsDtoByRestaurantId(restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallproductdetailsdtobycategoryidandrestaurantid")]
        public IActionResult GetAllProductDetailsDtoByCategoryIdAndRestaurantId(int categoryId,int restaurantId)
        {
            var result = _productService.GetAllProductDetailsDtoByCategoryIdAndRestaurantId(categoryId, restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
