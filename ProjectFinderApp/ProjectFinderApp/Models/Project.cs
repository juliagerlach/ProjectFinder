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
        public int ID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDesigner { get; set; }
        [ForeignKey("MagazineTitle")]
        public string MagazineTitle { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        public string PublisherLink { get; set; }
        public string OnlineLink { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
    }
}