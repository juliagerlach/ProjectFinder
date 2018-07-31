using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Subscriber")]
        public string SubscriptionType { get; set; }
        public Subscriber Subscriber { get; set; }

        [ForeignKey("RegisteredUser")]
        public string AccessType { get; set; }
        public RegisteredUser RegisteredUser { get; set; }
    }
}