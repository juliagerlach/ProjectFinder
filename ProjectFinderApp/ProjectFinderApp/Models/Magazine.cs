using System.Collections.Generic;

namespace ProjectFinderApp.Models
{
    public class Magazine
    {
        public int MagazineID {get; set;}
        public string MagazineTitle { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}