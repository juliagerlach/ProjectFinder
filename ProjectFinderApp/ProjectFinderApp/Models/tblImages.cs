using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.Models
{
    public class TblImages
    {
        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
        public int Size { get; set;}
        public FileType VarBinary { get; set; }


    }
}