namespace SlotEase.Application.DTOs.Doctors;

public class DoctorDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string RoomNo { get; set; } = string.Empty;
    public int ConsultationMinutes { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
}