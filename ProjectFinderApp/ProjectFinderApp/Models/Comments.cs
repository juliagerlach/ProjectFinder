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

        [ForeignKey("ApplicationUser")]
        public string UserName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}