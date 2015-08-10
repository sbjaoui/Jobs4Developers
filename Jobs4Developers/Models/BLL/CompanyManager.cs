using System.Collections.Generic;
using System.Linq;
using Jobs4Developers.Models.Utils;

namespace Jobs4Developers.Models.BLL
{
    public class CompanyManager
    {
        public static void Add(Company company)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Companys.Add(company);
                db.SaveChanges();
            }

        }
        public static Company GetByIdUser(string id, ApplicationDbContext db = null)
        {
            Company company = null;
            if (db == null)
            {
                using (db = new ApplicationDbContext())
                {
                    company = db.Companys.Include("Offers").Include("Languages").Where(h => h.UserId == id).FirstOrDefault();
                }
            }
            else
            {
                company = db.Companys.Include("Offers").Include("Languages").Where(h => h.UserId == id).FirstOrDefault();
            }
            company.UserId = id;
            company.LanguagesIds = string.Join(",", company.Languages.Select(h => h.Id));

            return company;
        }
        public static Company GetById(int id, ApplicationDbContext db = null)
        {
            Company company = null;
            if (db == null)
            {
                using (db = new ApplicationDbContext())
                {
                    company = db.Companys.Include("Offers").Include("Languages").Where(h => h.Id == id).FirstOrDefault();
                }
            }
            else
            {
                company = db.Companys.Include("Offers").Include("Languages").Where(h => h.Id == id).FirstOrDefault();
            }
            company.LanguagesIds = string.Join(",", company.Languages.Select(h => h.Id));
            return company;
        }
        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Company myCompany = GetById(id, db);
                if (myCompany != null)
                {
                    db.Companys.Remove(myCompany);
                    db.SaveChanges();
                }
            }
        }
        public static void Edit(Company companyModified)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //1. chercher dans la bd
                Company companyInBd = GetByIdUser(companyModified.UserId, db);

                //2. modifier
                companyInBd.Name = companyModified.Name;
                companyInBd.Description = companyModified.Description;
                companyInBd.PhoneNumber = companyModified.PhoneNumber;
                companyInBd.Adresse = companyModified.Adresse;




                List<int> oldIds = companyInBd.LanguagesIds.ToListOfInt();
                List<int> newIds = null;
                if (companyModified.LanguagesIds != null)
                {
                    newIds = companyModified.LanguagesIds.ToListOfInt();
                }
                else
                {
                    newIds = new List<int>();
                }

                Language languageToAdd = null;
                Language languageToRemove = null;

                // add new Language
                foreach (int id in newIds)
                {
                    if (!oldIds.Contains(id))
                    {
                        languageToAdd = db.Languages.Where(m => m.Id == id).FirstOrDefault();
                        companyInBd.Languages.Add(languageToAdd);
                    }
                }

                // remove deleted languages
                foreach (int id in oldIds)
                {
                    if (!newIds.Contains(id))
                    {
                        languageToRemove = db.Languages.Where(m => m.Id == id).FirstOrDefault();
                        companyInBd.Languages.Remove(languageToRemove);
                    }
                }

                //3. savechanges
                db.SaveChanges();
            }
        }
    }
}