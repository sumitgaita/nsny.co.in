using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class DatabaseBackUp
    {
       public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public bool IsDeleted { get; set; }
    }
  
}