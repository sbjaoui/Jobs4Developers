using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}