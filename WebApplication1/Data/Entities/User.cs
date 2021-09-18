using API.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [MinLength(5, ErrorMessage = "The field {0} must be at least {1} characters length.")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [MinLength(5, ErrorMessage = "The field {0} must be at least {1} characters length.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [MinLength(10, ErrorMessage = "The field {0} must be at least {1} characters length.")]
        public string Phone { get; set; }
    }
}
