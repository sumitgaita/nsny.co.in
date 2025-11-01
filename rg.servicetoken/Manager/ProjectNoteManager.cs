using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class ProjectNoteManager: IProjectNoteManager
    {
        public ProjectNote ProjectNoteDetails(ProjectNote noteDetails)
        {
            var data = new ProjectNoteData();

            return data.ProjectNoteDetails(noteDetails);
        }

        public bool ProjectNoteWeather(ProjectNote pn)
        {
            var data = new ProjectNoteData();

            return data.ProjectNoteWeather(pn);
        }

    }
}