namespace Jobs4Developers.Migrations
{
    using Jobs4Developers.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Jobs4Developers.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Jobs4Developers.Models.ApplicationDbContext context)
        {
           //AddAdminUser(ApplicationDbContext context)
        }
        public void AddAdminUser(ApplicationDbContext context)
        {
            UserStore<ApplicationUser> userstore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userstore);
            if (!context.Users.Any(u => u.UserName == "admin@isi.com"))
            {
                ApplicationUser newUser = new ApplicationUser { Email = "admin@isi.com", UserName = "admin@isi.com" };
                userManager.Create(newUser, "AAA111...");
                userManager.AddToRole(newUser.Id, "Admin");
            }
        }
    }
}
