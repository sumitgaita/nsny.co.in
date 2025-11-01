using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.Models
{
    public class ProjectNote
    {
        public int ProjectNoteId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectNoteDetails { get; set; }
        public string ProjectWeather { get; set; }
        public DateTime CreateDate { get; set; }

    }
}