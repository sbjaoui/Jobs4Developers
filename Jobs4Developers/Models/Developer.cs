using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models
{
    public class Developer
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
        public string ProfessionalInfo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string UrlImg { get; set; }
        public virtual ICollection<Developer> Developers { get; set; }
        public virtual ICollection<Language> Languages { get; set; }    
        public virtual ICollection<Education> Educations { get; set; }
    }
}