using Microsoft.EntityFrameworkCore;
using SlotEase.Application.DTOs.Doctors;
using SlotEase.Application.Exceptions;
using SlotEase.Application.Interfaces;
using SlotEase.Domain.Entities;
using SlotEase.Infrastructure.Persistence;

namespace SlotEase.Infrastructure.Services;

public class DoctorService : IDoctorService
{
    private readonly AppDbContext _db;

    public DoctorService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<DoctorDto>> GetAllAsync(int? departmentId)
    {
        var query = _db.Doctors.AsNoTracking();

        if (departmentId.HasValue)
        {
            query = query.Where(d => d.DepartmentId == departmentId.Value);
        }

        return await query
            .OrderBy(d => d.FullName)
            .Select(d => new DoctorDto
            {
                Id = d.Id,
                FullName = d.FullName,
                Specialization = d.Specialization,
                RoomNo = d.RoomNo,
                ConsultationMinutes = d.ConsultationMinutes,
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Department.Name
            })
            .ToListAsync();
    }

    public async Task<DoctorDto> CreateAsync(CreateDoctorDto dto)
    {
        var department = await _db.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == dto.DepartmentId);

        if (department is null)
        {
            throw new NotFoundException($"Department with id {dto.DepartmentId} was not found.");
        }

        var doctor = new Doctor
        {
            FullName = dto.FullName.Trim(),
            Specialization = dto.Specialization.Trim(),
            RoomNo = dto.RoomNo.Trim(),
            ConsultationMinutes = dto.ConsultationMinutes,
            DepartmentId = department.Id
        };

        _db.Doctors.Add(doctor);
        await _db.SaveChangesAsync();

        return new DoctorDto
        {
            Id = doctor.Id,
            FullName = doctor.FullName,
            Specialization = doctor.Specialization,
            RoomNo = doctor.RoomNo,
            ConsultationMinutes = doctor.ConsultationMinutes,
            DepartmentId = department.Id,
            DepartmentName = department.Name
        };
    }
}