using Jobs4Developers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobs4Developers.Controllers
{
    [Authorize(Roles = "Developer")]
    public class DeveloperController : Controller
    {
        [AllowAnonymous]
        public ActionResult PortFolio()
        {
          return View();
        }

        [AllowAnonymous]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Developer developer)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Developer developer)
        {
            return View();
        }
    }
}