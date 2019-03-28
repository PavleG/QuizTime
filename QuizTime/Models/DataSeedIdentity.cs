using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace QuizTime.Models{
    public class SeedDataIdentity{
        private const string adminUser = "DefaultQuizMaster";
        private const string adminPassword = "Default@123";
        private const string adminEmail = "default@mail.com";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .GetRequiredService<AppIdentityDbContext>();
            context.Database.Migrate();
            UserManager<User> userManager = app.ApplicationServices.
                GetRequiredService<UserManager<User>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.
                GetRequiredService<RoleManager<IdentityRole>>();

            User user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new User{
                    UserName = adminUser,
                    Email = adminEmail
                };
                await userManager.CreateAsync(user, adminPassword);
            }

            var roleExist = await roleManager.RoleExistsAsync("QuizMaster");
            if (!roleExist)
            {

                await roleManager.CreateAsync(new IdentityRole("QuizMaster"));
            }

            await userManager.AddToRoleAsync(user, "QuizMaster");
        }
    }
}