using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<SeatController> _logger;

        public SeatController(ILogger<SeatController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("FreeByPerformance/{performanceId}")]
        public async Task<IActionResult> GetFreeSeatByPerformance(Guid performanceId)
        {
            try
            {
                var response = await _mediator.Send(new GetFreeSeatByPerformanceQuery() { PerformanceId = performanceId});
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
