using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Domain.Identity;

namespace MyBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(MyBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name="Admin",
                    NormalizedName="ADMIN",
                    DisplayName="Quản trị viên",
                }) ;
                await context.SaveChangesAsync();
            }
            if (!context.Users.Any())
            {
                var userID=Guid.NewGuid();
                var user = new AppUser()
                {
                    Id=userID,
                    FirstName="Đức",
                    LastName="Lương Minh",
                    Email="ducbkap94@gmail.com",
                    NormalizedEmail="DUCBKAP94@GMAIL.COM",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    IsActive=true,
                    SecurityStamp=Guid.NewGuid().ToString(),
                    LockoutEnabled=false,
                    DateCreated=DateTime.Now,

                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123$");
                await context.Users.AddAsync(user);
                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId =userID,
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
