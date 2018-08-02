﻿using System;
using System.Collections;
using System.Collections.Generic;
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
        public string ProjectTitle { get; set; }
        public string Technique { get; set; }
        public string Supplies { get; set; }
        public string FilePath { get; set; }
        public byte[] Image { get; set; }
        public string ContactInfo { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}