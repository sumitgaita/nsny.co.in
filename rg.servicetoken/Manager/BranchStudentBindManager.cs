using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class BranchStudentBindManager : IBranchStudentBindManager
    {

        public bool CreateBranchStudentBind(BranchStudentBind branchStudentBind)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            int exitingAmmount = data.CheckWalletBalance(branchStudentBind.Scbid, branchStudentBind.Sccid);
            if (exitingAmmount == 11111111)
            {
                return data.CreateBranchStudentBind(branchStudentBind);
            }
            else if (exitingAmmount >= 0)
            {
                return data.CreateBranchStudentBind(branchStudentBind);
            }
            else
            {
                return false;
            }

        }

        public bool CreatePaymentollection(BranchPaymentCollection branchPaymentCollection)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.CreatePaymentollection(branchPaymentCollection);
        }
        public bool PaymentLastUpdate(BranchPaymentCollection branchPaymentCollection)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.PaymentLastUpdate(branchPaymentCollection);
        }
        public List<BranchPaymentCollection> GetBranchPaymentCollection(int branchId)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.GetBranchPaymentCollection(branchId);
        }
        public List<BranchPaymentCollection> GetRecivedPrint(string stid)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.GetRecivedPrint(stid);
        }
        public List<BranchPaymentCollection> GetBranchPaymenteraning(int branchId, string fromdate, string todate)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.GetBranchPaymenteraning(branchId, fromdate, todate);
        }
        public int PaymenCount(int branchId, string dt)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.PaymenCount(branchId, dt);

        }
        public List<BranchPaymentCollection> GetStuRegistrationList(int branchId, string fromdate, string todate)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.GetStuRegistrationList(branchId, fromdate, todate);
        }
        public List<BranchPaymentCollection> GetAdminStudentIcard(int branchId, string fromdate, string todate)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.GetAdminStudentIcard(branchId, fromdate, todate);
        }
        public List<BranchPaymentCollection> GetCourseBindList(string stid)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.GetCourseBindList(stid);
        }
        public bool StudentCourseBindUpdate(BranchStudentBind branchStudentBind)
        {
            BranchStudentBindData data = new BranchStudentBindData();
            return data.StudentCourseBindUpdate(branchStudentBind);
        }
        //public Project ProjectDetails(Project projectdetails)
        //{
        //    var data = new ProjectData();

        //    return data.ProjectDetails(projectdetails);
        //}

        //public bool ShowProject(Project projects)
        //{
        //    var data = new ProjectData();

        //    return data.ShowProject(projects);
        //}

        //public bool HideProject(Project projects)
        //{
        //    var data = new ProjectData();

        //    return data.HideProject(projects);
        //}

        //public List<Project> GetAdminUserProjects(Project loginId)
        //{
        //    var data = new ProjectData();
        //    return data.GetAdminUserProjects(loginId);
        //}

        //public List<Project> GetAdminUserHiddenProjects(Project loginId)
        //{
        //    var data = new ProjectData();
        //    return data.GetAdminUserHiddenProjects(loginId);
        //}

        //public List<Project> AdminUserProjectList(Project loginId)
        //{
        //    var data = new ProjectData();
        //    return data.AdminUserProjectList(loginId);
        //}

        ////public Project ProjectNameClientName(Project pro)
        //    //{
        //    //    var data = new ProjectData();

        //    //    return data.ProjectNameClientName(pro);
        //    //}
    }
}