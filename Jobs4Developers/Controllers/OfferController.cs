using Jobs4Developers.Models;
using Jobs4Developers.Models.BLL;
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
            offer.CompanyId = 1;
            OfferManager.Add(offer);
            ModelState.Clear();

            return RedirectToAction("Index", "Company");
        }
    }
}