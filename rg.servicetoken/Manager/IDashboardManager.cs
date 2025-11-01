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
        int NumberofBranchStudents(string Center_code, string likestr);
    }
}