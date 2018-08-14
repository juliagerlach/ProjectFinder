using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Project Title")]
        public string ProjectTitle { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        [DisplayName("Image")]
        public string FilePath1 { get; set; }
        [DisplayName("PDF")]
        public string FilePath2 { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public HttpPostedFileBase File1 { get; set; }

        [NotMapped]
        public HttpPostedFileBase File2 { get; set; }

        [DisplayName("Designer's Contact Info")]
        public string ContactInfo { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }       
    }
}