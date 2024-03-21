using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystem.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();
        builder.HasData(
            new AppUser
            {
                Id = "4000b844-74ca-479b-badb-4f41850ae07e",
                Email = "Admin@TMS.com",
                NormalizedEmail = "ADMIN@HR.COM",
                UserName = "Admin@TMS.com",
                NormalizedUserName = "ADMIN@HR.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = false
            },

            new AppUser
            {
                Id = "efa06a55-d0cc-4e01-abbf-870f21d91441",
                Email = "User@TMS.com",
                NormalizedEmail = "USER@HR.COM",
                UserName = "User@TMS.com",
                NormalizedUserName = "USER@HR.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword2"),
                EmailConfirmed = false
            }
        );
    }
}