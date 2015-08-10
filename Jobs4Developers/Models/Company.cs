using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
       
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(20)]
        public string Adresse { get; set; }
        [NotMapped]
        public string LanguagesIds { get; set; }
        public String UserId { get; set; }
        public virtual ICollection<Language> Languages { get; set; }


        public virtual ICollection<Offer> Offers { get; set; }

    }
}