using Microsoft.AspNetCore.Mvc;
using SlotEase.Application.DTOs.Doctors;
using SlotEase.Application.Interfaces;

namespace SlotEase.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DoctorDto>>> GetAll([FromQuery] int? departmentId)
    {
        var doctors = await _doctorService.GetAllAsync(departmentId);
        return Ok(doctors);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDto>> Create(CreateDoctorDto dto)
    {
        var created = await _doctorService.CreateAsync(dto);
        return Created($"/api/doctors/{created.Id}", created);
    }
}