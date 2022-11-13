using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "a3656108-9304-4efe-811e-5188debe14c1",
                    UserId = "d3656108-9304-4eee-811e-5188debe14c1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "d3856108-9304-4eaa-811e-5188dafe14c1",
                    UserId = "6689f13c-16b7-490d-8081-0002f7759d26"
                }
                );
        }
    }
}