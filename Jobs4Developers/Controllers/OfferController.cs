using Jobs4Developers.Models;
using Jobs4Developers.Models.BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobs4Developers.Controllers
{
    public class OfferController : Controller
    {



        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //model request binding 
        public ActionResult Add(Offer offer)
        {
            Company MyCompany = null;

            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindById(User.Identity.GetUserId());
                MyCompany = CompanyManager.GetByIdUser(user.Id);
                offer.CompanyId = MyCompany.Id;
                OfferManager.Add(offer);
                ModelState.Clear();

            }

            return RedirectToAction("Index", "Company");
        }
    }
}