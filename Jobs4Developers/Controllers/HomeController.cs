﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View("About");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
    }
}