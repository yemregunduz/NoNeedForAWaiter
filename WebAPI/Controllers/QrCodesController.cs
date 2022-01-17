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
    public class QrCodesController : ControllerBase
    {
        IQrCodeService _qrCodeService;
        public QrCodesController(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }
        [HttpPost("add")]
        public IActionResult Add(QrCode qrCode)
        {
            var result = _qrCodeService.Add(qrCode);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(QrCode qrCode)
        {
            var result = _qrCodeService.Delete(qrCode);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(QrCode qrCode)
        {
            var result = _qrCodeService.Update(qrCode);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallqrcodetabledtosbyrestaurantid")]
        public IActionResult GetAllQrCodeTableDtosByRestaurantId(int restaurantId)
        {
            var result = _qrCodeService.GetAllQrCodeTableDtosByRestaurantId(restaurantId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallqrcodetabledtosbytableid")]
        public IActionResult GetAllQrCodeTableDtosByTableId(int tableId)
        {
            var result = _qrCodeService.GetAllQrCodeTableDtosByTableId(tableId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
