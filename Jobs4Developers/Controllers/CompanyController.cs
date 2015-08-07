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
            Company MyCompany = CompanyManager.GetById(1);
            MyCompany.Offers = OfferManager.getByIdCompany(MyCompany.Id);
            return View(MyCompany);
        }

    }
}