using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.Models
{
    public class RegisteredUser
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "User Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime AccessStartDate { get; set; }
        public DateTime AccessEndDate { get; set; }
        public bool AccessActive { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}