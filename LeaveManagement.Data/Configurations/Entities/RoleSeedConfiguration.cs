using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "a3656108-9304-4efe-811e-5188debe14c1",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "d3856108-9304-4eaa-811e-5188dafe14c1",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }
                );
        }
    }
}