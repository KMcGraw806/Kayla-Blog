namespace Kayla_Blog.Migrations
{
    using Kayla_Blog.Models;
    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kayla_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Kayla_Blog.Models.ApplicationDbContext context)
        {
            
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Now I need to go out and look for the presence of a user with a specific Email...
            //If and only if it IS NOT found will I create a user with that email
            if(!context.Users.Any(u => u.Email == "kayla_mcgraw@hotmail.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    UserName = "kayla_mcgraw@hotmail.com",
                    Email = "kayla_mcgraw@hotmail.com",
                    FirstName = "Kayla",
                    LastName = "McGraw",
                    DisplayName = "KMcGraw"
                }, "Simone2410");
            }
            
            if(!context.Users.Any(u => u.Email == "chris.cwm.1022@gmail.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    UserName = "chris.cwm.1022@gmail.com",
                    Email = "chris.cwm.1022@gmail.com",
                    FirstName = "Christopher",
                    LastName = "McGraw",
                    DisplayName = "CMcGraw"
                }, "100221Cm!");
            }

            var adminId = userManager.FindByEmail("kayla_mcgraw@hotmail.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var modId = userManager.FindByEmail("chris.cwm.1022@gmail.com").Id;
            userManager.AddToRole(modId, "Moderator");
        }
    }
}
