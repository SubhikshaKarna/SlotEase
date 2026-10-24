using Microsoft.EntityFrameworkCore;
using SlotEase.Application.DTOs.Departments;
using SlotEase.Application.Interfaces;
using SlotEase.Domain.Entities;
using SlotEase.Infrastructure.Persistence;

namespace SlotEase.Infrastructure.Services;

public class DepartmentService : IDepartmentService
{
    private readonly AppDbContext _db;

    public DepartmentService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<DepartmentDto>> GetAllAsync()
    {
        return await _db.Departments
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .Select(d => new DepartmentDto { Id = d.Id, Name = d.Name })
            .ToListAsync();
    }

    public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
    {
        var department = new Department { Name = dto.Name.Trim() };

        _db.Departments.Add(department);
        await _db.SaveChangesAsync();

        return new DepartmentDto { Id = department.Id, Name = department.Name };
    }
}