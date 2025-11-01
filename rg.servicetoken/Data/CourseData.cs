using rg.framework.Data;
using rg.service.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace rg.service.Data
{
    public class CourseData
    {
        private Factory myFactory;
        private Helpers hlpr;

        public CourseData()
        {
            myFactory = new Factory();
            hlpr = new Helpers();
        }

        public bool CreateCourse(Course course)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@name", course.Cname),
                myFactory.GetParameter("@modules", course.Cmodules),
                myFactory.GetParameter("@duration", course.Cduration),
                myFactory.GetParameter("@fullpay", course.Cfullpay),
                myFactory.GetParameter("@inspay_f", course.Cinspay_f),
                myFactory.GetParameter("@inspay_m", course.Cinspay_m),
                myFactory.GetParameter("@inspay_xm", course.Cinspay_xm),
                myFactory.GetParameter("@r1", course.Cabb),
                myFactory.GetParameter("@r2", ""),
                myFactory.GetParameter("@r3", course.Cr3),
                myFactory.GetParameter("@c1", course.C1),
                myFactory.GetParameter("@c2", course.C2),
                myFactory.GetParameter("@act", Convert.ToInt32(1)),
                myFactory.GetParameter("@hqamount", Convert.ToInt32(course.Hqamount))
            };
            return hlpr.ExecuteStoredProcedure("CouseInsert", ref parameters);
        }

        public bool UpdateCourse(Course course)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", course.Id),
                myFactory.GetParameter("@name", course.Cname),
                myFactory.GetParameter("@modules", course.Cmodules),
                myFactory.GetParameter("@duration", course.Cduration),
                myFactory.GetParameter("@fullpay", course.Cfullpay),
                myFactory.GetParameter("@inspay_f", course.Cinspay_f),
                myFactory.GetParameter("@inspay_m", course.Cinspay_m),
                myFactory.GetParameter("@inspay_xm", course.Cinspay_xm),
                myFactory.GetParameter("@r1", course.Cabb),
                myFactory.GetParameter("@r2", ""),
                myFactory.GetParameter("@r3", course.Cr3),
                myFactory.GetParameter("@c1", course.C1),
                myFactory.GetParameter("@c2", course.C2),
                myFactory.GetParameter("@act", Convert.ToInt32(1)),
                myFactory.GetParameter("@hqamount", Convert.ToInt32(course.Hqamount))

             };
            return hlpr.ExecuteStoredProcedure("CouseUpdate", ref parameters);

        }

        public bool DeleteCourse(Course per)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
            {
                myFactory.GetParameter("@id", per.Id)
            };
            return hlpr.ExecuteStoredProcedure("DeleteCourse", ref parameters);

        }
       

        public List<Course> GetAllCourse()
        {
            List<Course> course = new List<Course>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetCourseList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                course.Add(new Course()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Cname = row["name"].ToString(),
                    Cabb = row["r1"].ToString(),
                    Cmodules = row["modules"].ToString(),
                    Cduration = row["duration"].ToString(),
                    C1 = row["c1"].ToString(),
                    C2 = row["c2"].ToString(),
                    Cfullpay = !row.IsNull("fullpay") ? Convert.ToInt32(row["fullpay"]) : 0,
                    Cinspay_f = !row.IsNull("inspay_f") ? Convert.ToInt32(row["inspay_f"]) : 0,
                    Cr3 = !row.IsNull("r3") ? Convert.ToInt32(row["r3"]) : 0,
                    Cinspay_m = !row.IsNull("inspay_m") ? Convert.ToInt32(row["inspay_m"]) : 0,
                    Cinspay_xm = !row.IsNull("inspay_xm") ? Convert.ToInt32(row["inspay_xm"]) : 0,
                    Hqamount = !row.IsNull("hqamount") ? Convert.ToInt32(row["hqamount"]) : 0
                });
            }
            return course;

        }

        public List<Course> GetAllActiveCourse()
        {
            List<Course> course = new List<Course>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string query = "GetActiveCourseList";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                course.Add(new Course()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Cname = row["name"].ToString(),
                    Cabb = row["r1"].ToString(),
                    Cmodules = row["modules"].ToString(),
                    Cduration = row["duration"].ToString(),
                    C1 = row["c1"].ToString(),
                    C2 = row["c2"].ToString(),
                    Cfullpay = !row.IsNull("fullpay") ? Convert.ToInt32(row["fullpay"]) : 0,
                    Cinspay_f = !row.IsNull("inspay_f") ? Convert.ToInt32(row["inspay_f"]) : 0,
                    Cr3 = !row.IsNull("r3") ? Convert.ToInt32(row["r3"]) : 0,
                    Cinspay_m = !row.IsNull("inspay_m") ? Convert.ToInt32(row["inspay_m"]) : 0,
                    Cinspay_xm = !row.IsNull("inspay_xm") ? Convert.ToInt32(row["inspay_xm"]) : 0,
                    Hqamount = !row.IsNull("hqamount") ? Convert.ToInt32(row["hqamount"]) : 0
                });
            }
            return course;

        }

        public List<Course> GetByIdCourse(Course courses)
        {
            List<Course> course = new List<Course>();
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(myFactory.GetParameter("@id", courses.Id));
            string query = "CourseMode";
            DataTable tbl = hlpr.GetDataTable(query, ref parameters);


            foreach (DataRow row in tbl.Rows)
            {
                course.Add(new Course()
                {

                    Id = Convert.ToInt32(row["id"]),
                    Cname = row["name"].ToString(),
                    Cabb = row["r1"].ToString(),
                    Cmodules = row["modules"].ToString(),
                    Cduration = row["duration"].ToString(),
                    C1 = row["c1"].ToString(),
                    C2 = row["c2"].ToString(),
                    Cfullpay = !row.IsNull("fullpay") ? Convert.ToInt32(row["fullpay"]) : 0,
                    Cinspay_f = !row.IsNull("inspay_f") ? Convert.ToInt32(row["inspay_f"]) : 0,
                    Cr3 = !row.IsNull("r3") ? Convert.ToInt32(row["r3"]) : 0,
                    Cinspay_m = !row.IsNull("inspay_m") ? Convert.ToInt32(row["inspay_m"]) : 0,
                    Cinspay_xm = !row.IsNull("inspay_xm") ? Convert.ToInt32(row["inspay_xm"]) : 0,
                    Hqamount = !row.IsNull("hqamount") ? Convert.ToInt32(row["hqamount"]) : 0
                });
            }
            return course;

        }

       
    }
}