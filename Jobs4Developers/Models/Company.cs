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
        [MaxLength((50))]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength((50))]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string UrlLogo { get; set; }
        [NotMapped]
        public string LanguagesIds { get; set; }
        public virtual ICollection<Language> Languages { get; set; }


        public virtual ICollection<Offer> Offers { get; set; }

    }
}