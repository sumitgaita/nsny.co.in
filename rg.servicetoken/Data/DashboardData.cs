using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class DashboardData
    {
        private readonly Factory myFactory;
        private Helpers hlpr;

        public DashboardData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }
        public int NumberofStudents()
        {
            int details=0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "AdminBranchstudentCount";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        public int NumberofBranchStudents(string Center_code,string likestr)
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    myFactory.GetParameter("@Center_code", Center_code),
                    myFactory.GetParameter("@likestr", likestr)
                };
            string query = "BranchstudentCount";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        public int NumberofCourse()
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "CourseCount";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        public int NumberofBranche()
        {
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "AdminBranchCount";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        
    }
}