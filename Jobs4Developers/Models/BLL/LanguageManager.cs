using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models.BLL
{
    public class LanguageManager
    {
        public static IEnumerable<Language> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Languages.OrderBy(h => h.Name).ToList();
            }
        }
        public static void Add(Language language)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {


                db.Languages.Add(language);
                db.SaveChanges();
            }
        }
        public static Language GetById(int id, ApplicationDbContext db = null)
        {
            Language language = null;
            if (db == null)
            {
                using (db = new ApplicationDbContext())
                {
                    language = db.Languages.Find(id);
                }
            }
            else
            {
                language = db.Languages.Where(h => h.Id == id).FirstOrDefault();
            }
            return language;
        }
    }
}
