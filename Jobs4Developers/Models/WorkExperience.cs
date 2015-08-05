using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string JobPosition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
       
        public virtual ICollection<Developer> Developers { get; set; }

    }
}