using Microsoft.EntityFrameworkCore;
using SlotEase.Domain.Entities;

namespace SlotEase.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Doctor> Doctors => Set<Doctor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(e =>
        {
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Doctor>(e =>
        {
            e.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            e.Property(x => x.Specialization).HasMaxLength(100);
            e.Property(x => x.RoomNo).HasMaxLength(20);

            e.HasOne(x => x.Department)
             .WithMany(d => d.Doctors)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
