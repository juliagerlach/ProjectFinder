using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFinderApp.Models
{
    public class Issue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IssueID { get; set; }
        public string IssueMonth { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}