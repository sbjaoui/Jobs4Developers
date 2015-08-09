using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models.BLL
{
    public  class WorkExperienceManager
    {
        public static void Add(WorkExperience workExperience)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
              
               


                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    db.WorkExperiences.Add(workExperience);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }
        }
    }
}