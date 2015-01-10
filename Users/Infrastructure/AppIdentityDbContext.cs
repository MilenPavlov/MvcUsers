using System.CodeDom;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Users.Models;

namespace Users.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() :base("IdentityDb") {}

        static AppIdentityDbContext()
        {
           Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext>
    {
        //protected override void Seed(AppIdentityDbContext context)
        //{
        //    PerformInitialSetup(context);
        //    base.Seed(context);
        //}

        //private void PerformInitialSetup(AppIdentityDbContext context)
        //{
        //    var userManager = new AppUserManager(new UserStore<AppUser>(context));
        //    var roleManager = new AppRoleManager(new RoleStore<AppRole>(context));

        //    string roleName = "Administrators";
        //    var userName = "Admin";
        //    var password = "MySecret";
        //    string email = "admin@example.com";

        //    if (!roleManager.RoleExists(roleName))
        //    {
        //        roleManager.Create(new AppRole(roleName));
        //    }

        //    var user = userManager.FindByName(userName);

        //    if (user == null)
        //    {
        //        userManager.Create(new AppUser {UserName = userName, Email = email}, password);

        //        user = userManager.FindByName(userName);
        //    }

        //    if (!userManager.IsInRole(user.Id, roleName))
        //    {
        //        userManager.AddToRole(user.Id, roleName);
        //    }
        //}
    }
}
