using Dsw2026Tpi.Application.Dtos;
using Dsw2026Tpi.Application.Interfaces;
using Dsw2026Tpi.CrossCutting.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Dsw2026Tpi.Api.Controllers;

[Route("api/doctors")]
<<<<<<< HEAD
[ApiController]
[EnableRateLimiting("GeneralPolicy")]
public class DoctorController : AppController
{
    private readonly IDoctorService _doctorService;
    private readonly IAvailabilityService _availabilityService;

    public DoctorController(IDoctorService doctorService, IAvailabilityService availabilityService)
    {
        _doctorService = doctorService;
=======
public class DoctorController : AppController
{
    private readonly IDoctorService _service;
    private readonly IAvailabilityRuleService _availabilityService;

    public DoctorController(IDoctorService service, IAvailabilityRuleService availabilityService)
    {
        _service = service;
>>>>>>> development
        _availabilityService = availabilityService;
    }


    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
<<<<<<< HEAD
    public async Task<IActionResult> GetAll([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1, [FromQuery] string? name = null)
=======
    public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int pageIndex, [FromQuery] string? name = null)
>>>>>>> development
    {
        var doctors = await _doctorService.GetAll(pageSize, pageIndex, name);
        return Ok(doctors);
    }

<<<<<<< HEAD
    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doctor = await _doctorService.GetById(id);
        if (doctor is null)
            return NotFound();
        return Ok(doctor);
    }

    [HttpGet("{id}/availabilities")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAvailabilities(Guid id)
    {
        var availabilities = await _availabilityService.GetDoctorAvailabilities(id);
        return Ok(availabilities);
    }

    [HttpPost]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody] DoctorModel.Request request)
    {
        var result = await _doctorService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] DoctorModel.Request request)
    {
        var result = await _doctorService.Update(id, request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _doctorService.Delete(id);
        return Ok("ok");
=======
    [HttpPost]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] DoctorModel.Request request)
    {
        var doctor = await _service.Create(request);
        return Created(string.Empty, doctor);
    }

    [HttpGet("{id:guid}/availabilities")]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailabilities(Guid id)
    {
        var availabilities = await _availabilityService.GetByDoctor(id);
        return Ok(availabilities);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(Guid id, [FromBody] DoctorModel.Request request)
    {
        var doctor = await _service.Update(id, request);
        return Ok(doctor);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = Policies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);
        return Ok("Ok");
>>>>>>> development
    }
}
