using SlotEase.Application.DTOs.Doctors;

namespace SlotEase.Application.Interfaces;

public interface IDoctorService
{
    Task<List<DoctorDto>> GetAllAsync(int? departmentId);
    Task<DoctorDto> CreateAsync(CreateDoctorDto dto);
}