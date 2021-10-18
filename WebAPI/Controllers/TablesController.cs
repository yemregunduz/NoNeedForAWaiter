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
    public class TablesController : ControllerBase
    {
        ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }
        [HttpPost("add")]
        public IActionResult Add(Table table)
        {
            var result = _tableService.Add(table);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Table table)
        {
            var result = _tableService.Delete(table);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Table table)
        {
            var result = _tableService.Update(table);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalltablesbyrestaurantid")]
        public IActionResult GetAllTableByRestaurantId(int restaurantId)
        {
            var result = _tableService.GetAllTablesByRestaurantId(restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
