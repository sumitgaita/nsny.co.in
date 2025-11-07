using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class DashboardManager : IDashboardManager
    {
        public int NumberofStudents()
        {
            var data = new DashboardData();
            return data.NumberofStudents();
        }

        public int NumberofCourse()
        {
            var data = new DashboardData();
            return data.NumberofCourse();
        }
        public int NumberofBranche()
        {
            var data = new DashboardData();
            return data.NumberofBranche();
        }
       public int NumberofBranchStudents(string Center_code, string likestr)
        {
            var data = new DashboardData();
            return data.NumberofBranchStudents(Center_code, likestr);
        }


        public List<Student> GetStudentImage(string name, string nssy_code, string Center_code)
        {
            var data = new DashboardData();
            return data.GetStudentImage(name, nssy_code, Center_code);
        }
    }
}