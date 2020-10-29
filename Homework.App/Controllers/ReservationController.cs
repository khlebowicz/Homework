using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(ILogger<ReservationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservationCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                // if (!response.IsValid)
                //    return BadRequest(response.Errors);
                // return Ok(response.Result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buy")]
        public async Task<IActionResult> Buy([FromBody] BuyReservationCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                // if (!response.IsValid)
                //    return BadRequest(response.Errors);
                // return Ok(response.Result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
