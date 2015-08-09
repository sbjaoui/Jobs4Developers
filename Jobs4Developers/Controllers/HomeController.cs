using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Jobs4Developers.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Jobs4Developers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        public ActionResult Start()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                RedirectToAction("Login", "Account");
            }
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindById(User.Identity.GetUserId());
                var nameUSer = user.Email;
                var userId = user.Id;

            }
            return View("PortFolio");
        }

       

       
    }
}