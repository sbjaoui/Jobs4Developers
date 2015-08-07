using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models.BLL
{
    public class CompanyManager{
    
     

        public static Company GetById(int id, ApplicationDbContext db = null) { 
            Company company = null;
            if(db == null){
                using(db= new ApplicationDbContext()){
                    company = db.Companies.Find(id);
                }
            }else{
                company = db.Companies.Include("Offer").Where(h => h.Id == id).FirstOrDefault();
            }
            return company;
        }
    }
}