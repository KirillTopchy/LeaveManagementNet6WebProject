using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "d3656108-9304-4eee-811e-5188debe14c1",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    UserName = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    FirstName = "Admin",
                    LastName = "Test",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "6689f13c-16b7-490d-8081-0002f7759d26",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
                );
        }
    }
}