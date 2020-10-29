using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PerformanceController> _logger;

        public PerformanceController(ILogger<PerformanceController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetPerformanceQuery());
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _mediator.Send(new GetPerformanceQuery() { Id = id });
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

        //// POST api/<PerformanceController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PerformanceController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PerformanceController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
