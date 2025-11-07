using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            int details = 0;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "AdminBranchstudentCount";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);
            foreach (DataRow row in tbl.Rows)
            {
                details = !row.IsNull(0) ? Convert.ToInt32(row[0]) : 0;

            }
            return details;
        }
        public int NumberofBranchStudents(string Center_code, string likestr)
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
        public List<Student> GetStudentImage(string name, string nssy_code, string Center_code)
        {
            List<Student> student = new List<Student>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            if (!string.IsNullOrEmpty(name) && name.Trim().ToLower() != "null")
                parameters.Add(myFactory.GetParameter("@name", name));

            if (!string.IsNullOrEmpty(Center_code) && Center_code.Trim().ToLower() != "null"
                && Center_code != "0")
                parameters.Add(myFactory.GetParameter("@Center_code", Center_code));

            if (!string.IsNullOrEmpty(nssy_code) && nssy_code.Trim().ToLower() != "null")
                parameters.Add(myFactory.GetParameter("@NSSY_code", nssy_code));

            string query = "GetAllImageList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                student.Add(new Student()
                {

                    Stu_name = row["name"].ToString(),
                    NSSY_code = row["NSSY_code"].ToString(),
                    Center_name = row["Center_name"].ToString(),
                    Pic = ConfigurationManager.AppSettings["imagePath"] + row["pic"].ToString(),
                    Center_code = row["Center_code"].ToString()
                });
            }
            return student;

        }
    }
}