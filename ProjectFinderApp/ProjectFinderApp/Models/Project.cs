using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDesigner { get; set; }
        public int MagazineID { get; set; }
        public int IssueID { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        public string PublisherLink { get; set; }
        public string OnlineLink { get; set; }
        public virtual Magazine Magazine { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
    }
}