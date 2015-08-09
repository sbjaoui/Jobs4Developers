namespace Jobs4Developers.Migrations
{
    using Jobs4Developers.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Jobs4Developers.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed (Jobs4Developers.Models.ApplicationDbContext context)
        {
            AddSomeRoles(context);
        }


        public void AddSomeRoles(Jobs4Developers.Models.ApplicationDbContext context)
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{Name="Developer"},
                new IdentityRole{Name="Entreprise"},
            };

            foreach (IdentityRole role in roles)
            {
                context.Roles.AddOrUpdate(r => r.Name, role);
            }
        }
    }
}
