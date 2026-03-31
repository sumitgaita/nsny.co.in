using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IDashboardManager
    {

        int NumberofStudents();
        int NumberofCourse();
        int NumberofBranche();
        int NumberofBranchCenter(string Center_code);
        int NumberofBranchStudents(string Center_code, string likestr);
        List<Student> GetStudentImage(string name, string nssy_code, string Center_code);
    }
}