using Microsoft.AspNetCore.Mvc;
using SlotEase.Application.DTOs.Departments;
using SlotEase.Application.Exceptions;
using SlotEase.Application.Interfaces;

namespace SlotEase.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DepartmentDto>>> GetAll()
    {
        var departments = await _departmentService.GetAllAsync();
        return Ok(departments);
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> Create(CreateDepartmentDto dto)
    {
        try
        {
            var created = await _departmentService.CreateAsync(dto);
            return Created($"/api/departments/{created.Id}", created);
        }
        catch (ConflictException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}