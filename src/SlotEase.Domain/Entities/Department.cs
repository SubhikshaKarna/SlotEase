using SlotEase.Domain.Common;

namespace SlotEase.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
