using FuelDispenseAPI.Models;
using FuelDispenseAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuelDispenseAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class RecordsController : ControllerBase
    {
        private readonly IDispenseService _service;

        public RecordsController(IDispenseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateRecordRequest req)
        {
            var result = await _service.CreateRecord(req);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string dispenserNo,
            [FromQuery] string paymentMode,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            var data = await _service.GetRecords(dispenserNo, paymentMode, startDate, endDate);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadProof(int id)
        {
             try
            {
                
                var (fileBytes, fileName, contentType) = await _service.DownloadProof(id);

                if (fileBytes == null)
                {
                    return NotFound("File not found for the specified record.");
                }

                return File(
             fileContents: fileBytes,
             contentType: contentType, 
             fileDownloadName: fileName
              );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
