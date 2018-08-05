namespace SoftUniClone.Web.Common
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using SoftUniClone.Models;

    public static class ApplicationBuilderAuthExtensions
    {
        private const string DefaultAdminPass = "admin123";

        private static readonly IdentityRole[] roles = new IdentityRole[]
        {
            new IdentityRole("Administrator"),
            new IdentityRole("Lecturer"),
        };
        public static async void SeedDatabase(
            this IApplicationBuilder applicationBuilder)
        {
            var serviceFactoryApp = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactoryApp.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                var user = await userManager.FindByNameAsync("admin");

                if (user == null)
                {
                    user = new User()
                    {
                        UserName = "admin",
                        Email = "admin@example.com"
                    };

                    await userManager.CreateAsync(user, DefaultAdminPass);

                    await userManager.AddToRoleAsync(user, roles[0].Name);
                }
            }
        }
    }
}
