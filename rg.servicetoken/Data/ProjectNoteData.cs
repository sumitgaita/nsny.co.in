using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using rg.framework.Data;
using rg.service.Models;

namespace rg.service.Data
{
    public class ProjectNoteData
    {
        Factory myFactory;
        Helpers hlpr;

        public ProjectNoteData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }


        public ProjectNote ProjectNoteDetails(ProjectNote noteDetails)
        {
            var projectNoteDetails = new ProjectNote();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@ProjectID", noteDetails.ProjectId));
            parameters.Add(myFactory.GetParameter("@Date", noteDetails.CreateDate));
            string query = "Select_Note";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);

            foreach (DataRow row in tbl.Rows)
            {
                projectNoteDetails.ProjectNoteDetails = row["project_note"].ToString();
                projectNoteDetails.ProjectWeather = row["project_weather"].ToString();
               
            }
            return projectNoteDetails;

        }

        public bool ProjectNoteWeather(ProjectNote pn)
        {
          
            List <IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@ProjectID", pn.ProjectId));
            parameters.Add(myFactory.GetParameter("@Date", pn.CreateDate));
            parameters.Add(myFactory.GetParameter("@project_note", pn.ProjectNoteDetails));
            parameters.Add(myFactory.GetParameter("@project_weather", pn.ProjectWeather));
           
            //return hlpr.ExecuteDmlQuery("Add_New_user", ref parameters); 
            return hlpr.ExecuteStoredProcedure("ProjectNote", ref parameters);
        }
    }
}