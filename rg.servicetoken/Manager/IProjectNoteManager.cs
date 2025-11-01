using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IProjectNoteManager
    {
        ProjectNote ProjectNoteDetails(ProjectNote noteDetails);
        bool ProjectNoteWeather(ProjectNote pn);
    }
}