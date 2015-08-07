using Jobs4Developers.Models;
using Jobs4Developers.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobs4Developers.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //model request binding 
        public ActionResult Add(Language language,int? idl)
        {
          
            LanguageManager.Add(language);
            ModelState.Clear();

            return RedirectToAction("Edit", "Company", new { id = 1 });
        }
    }
}