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
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult GetAllProductsByCategoryId(int categoryId)
        {
            var result = _productService.GetAllProductsByCategoryId(categoryId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
