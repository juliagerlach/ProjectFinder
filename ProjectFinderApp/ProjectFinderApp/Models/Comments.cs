using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        
        public virtual Project project { get; set; }
    }
}