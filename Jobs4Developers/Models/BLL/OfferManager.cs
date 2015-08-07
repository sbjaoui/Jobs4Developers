using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models.BLL
{
    public class OfferManager
    {
        public static void Add(Offer offre)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {


                db.Offers.Add(offre);
                db.SaveChanges();
            }
        }
        public static ICollection<Offer> getByIdCompany(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

               ICollection<Offer>offers = db.Offers.Where(h => h.CompanyId == id).ToList();
               return offers;
            }
        }


    }
}