using Dsw2026Tpi.Application.Dtos;
<<<<<<< HEAD
using Dsw2026Tpi.Application.Interfaces;
using Dsw2026Tpi.CrossCutting.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Dsw2026Tpi.Api.Controllers;

[Route("api/availabilities")]
[ApiController]
[Authorize(Policy = Policies.AdminPolicy)]
[EnableRateLimiting("GeneralPolicy")]
public class AvailabilityController : AppController
{
    private readonly IAvailabilityService _service;

    public AvailabilityController(IAvailabilityService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create([FromBody] AvailabilityRequest request)
    {
        var result = await _service.Create(request);
        return Created(string.Empty, result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Update([FromBody] AvailabilityRequest request)
    {
        var result = await _service.Update(request);
        return Ok(result);
=======
using Dsw2026Tpi.CrossCutting.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Tpi.Application.Interfaces;

namespace Dsw2026Tpi.Api.Controllers
{
    [Route("api/availabilities")]
    [Authorize(Policy = Policies.AdminPolicy)]
    public class AvailabilityController : AppController
    {
        private readonly IAvailabilityRuleService _service;

        public AvailabilityController(IAvailabilityRuleService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AvailabilityRuleModel.Request request)
        {
            var availability = await _service.Create(request);
            return Created(string.Empty, availability);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] AvailabilityRuleModel.Request request)
        {
            var availability = await _service.Update(request.DoctorId, request);
            return Ok(availability);
        }
>>>>>>> development
    }
}
