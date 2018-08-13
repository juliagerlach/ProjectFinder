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
    public class PremiumContent : IEnumerable
    {
        [Key]
        public int ContentID { get; set; }
        [DisplayName("Project Title")]
        public string ProjectTitle { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        [DisplayName("Upload Image")]
        public string FilePath1 { get; set; }
        [DisplayName("Upload PDF")]
        public string FilePath2 { get; set; }

        [NotMapped]
        public HttpPostedFileBase File1 { get; set; }

        [NotMapped]
        public HttpPostedFileBase File2 { get; set; }

        [DisplayName("Your Contact Info")]
        public string ContactInfo { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}