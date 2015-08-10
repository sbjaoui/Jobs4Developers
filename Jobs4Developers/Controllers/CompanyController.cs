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
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Company company)
        {
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindById(User.Identity.GetUserId());
                company.UserId = user.Id;
            }
            if (ModelState.IsValid)
            {
                CompanyManager.Add(company);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View("../Company/Add", company);

        }
        public ActionResult Index()
        {

            Company myCompany = new Company();
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindById(User.Identity.GetUserId());


                myCompany = CompanyManager.GetByIdUser(user.Id);

                myCompany.UserId = user.Id;
                ViewBag.EmailUser = user;
            }



            ViewBag.ListOffres = OfferManager.getByIdCompany(myCompany.Id);

            return View(myCompany);
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(403);
            }
            else
            {
                Company myCompany = CompanyManager.GetById(id.Value);

                if (myCompany == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.ListOffres = OfferManager.getByIdCompany(id.Value);
                    return View(myCompany);
                }
            }
        }
        public ActionResult Delete(int? id)
        {

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(403);
            }
            else
            {
                CompanyManager.Delete(id.Value);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company myCompany)
        {
            var postData = Request.Form;

            if (ModelState.IsValid)
            {
                CompanyManager.Edit(myCompany);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListOffres = OfferManager.getByIdCompany(myCompany.Id);

                return View(myCompany);
            }
        }
    }
}