using SlotEase.Domain.Common;

namespace SlotEase.Domain.Entities;

public class Doctor : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string RoomNo { get; set; } = string.Empty;
    public int ConsultationMinutes { get; set; } = 15;

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}
