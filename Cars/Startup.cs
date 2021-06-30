using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // CreateDefaultRolesAndUsers();
        }

        //public void CreateDefaultRolesAndUsers()
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        //    IdentityRole role = new IdentityRole();
        //    if (!roleManager.RoleExists("Admins"))
        //    {
        //        role.Name = "Admins";
        //        roleManager.Create(role);
        //        ApplicationUser User = new ApplicationUser();
        //        User.UserName = "Ehabbbbb";
        //        User.Email = "ehabsallam123@gmail.com";
        //        var Check = userManager.Create(User, "Eh@aab123");
        //        if (Check.Succeeded)
        //        {
        //            userManager.AddToRole(User.Id, "Admins");
        //        }
        //    }
            
        //}
    }
}
