using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ModelConfigurations
{
    public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.OrganizationId, x.RoleId });
            builder.Property(x => x.EmployeeId)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(x => x.OrganizationId)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(x => x.RoleId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Organization)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Role)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("EmployeeRoles");
        }
    }
}
