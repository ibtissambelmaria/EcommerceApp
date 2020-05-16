using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAPP.Models
{
    public class ClientViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdressFacturation { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string LoggedOn { get; set; }
    }
}