﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  Jobs4Developers.Models;
using Jobs4Developers.Models.BLL;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Jobs4Developers.Controllers
{
    public class WorkExeprienceController : Controller
    {
        // GET: WorkExeprience
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addWorkExperience([Bind(Prefix = "Item1")] WorkExperience workExeprience)
        {

         workExeprience.UserId =  User.Identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindById(User.Identity.GetUserId());
                workExeprience.UserId = user.Id;
            }
            

            if (ModelState.IsValid)
            {
                WorkExperienceManager.Add(workExeprience);
                ModelState.Clear();
                return PartialView("_PartialViewWorkExeprience", workExeprience);
            }
            return PartialView("_PartialViewEmpty", workExeprience);
           
           
        }


    }
}