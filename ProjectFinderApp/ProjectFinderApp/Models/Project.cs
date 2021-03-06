﻿using System;
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
        [Display(Name = "Page #")]
        public int PageNumber { get; set; }

        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }
        public string ProjectType { get; set; }

        [Display(Name = "Designer")]
        public string ProjectDesigner { get; set; }

        [Display(Name = "Magazine")]
        public int MagazineID { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Issue")]
        public int IssueID { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        [Display(Name = "Find It Online")]
        public string OnlineLink { get; set; }

        [Display(Name = "Image")]
        public string FilePath { get; set; }
        public string FileName { get; set; }
        
        public virtual Magazine Magazine { get; set; }
        
    }
}