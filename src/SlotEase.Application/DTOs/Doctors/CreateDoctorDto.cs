using System.ComponentModel.DataAnnotations;

namespace SlotEase.Application.DTOs.Doctors;

public class CreateDoctorDto
{
    [Required(ErrorMessage = "Full name is required.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 150 characters.")]
    public string FullName { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
    public string Specialization { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Room number cannot exceed 20 characters.")]
    public string RoomNo { get; set; } = string.Empty;

    [Range(5, 120, ErrorMessage = "Consultation minutes must be between 5 and 120.")]
    public int ConsultationMinutes { get; set; } = 15;

    [Range(1, int.MaxValue, ErrorMessage = "A valid department is required.")]
    public int DepartmentId { get; set; }
}