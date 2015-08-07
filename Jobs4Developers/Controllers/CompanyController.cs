using Jobs4Developers.Models;
using Jobs4Developers.Models.BLL;
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
        public ActionResult Index()
        {
            Company myCompany = CompanyManager.GetById(1);
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