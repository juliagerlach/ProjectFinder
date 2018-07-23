using System.ComponentModel.DataAnnotations;

namespace ProjectFinderApp.Models
{
    public class FilePath
    {
        [Key]
        public int FilePathId { get; set; }
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

    }
}