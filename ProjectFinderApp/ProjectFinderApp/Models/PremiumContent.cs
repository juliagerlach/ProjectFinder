using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.Models
{
    public class PremiumContent
    {
        [Key]
        public int ContentID { get; set; }
        public string ProjectTitle { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        public string FileName { get; set; }
        public byte Image { get; set; }
        public string ContactInfo { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}