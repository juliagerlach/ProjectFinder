using System.ComponentModel.DataAnnotations;

namespace ProjectFinderApp.Models
{
    public class FilePath
    {
        [Key]
        public int FilePathId { get; set; }
        [StringLength(225)]
        public string FileName { get; set; }
        public int ContentID { get; set; }
        public virtual PremiumContent PremiumContent { get; set; }

    }
}