namespace ProjectFinderApp.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

    }
}