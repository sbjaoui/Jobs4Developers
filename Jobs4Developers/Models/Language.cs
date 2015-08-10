using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
    [MinLength(2)]
        public string Name { get; set; }
        public virtual ICollection<Developer> Developers { get; set; }
        public virtual ICollection<Company> Companys { get; set; }
    }
}