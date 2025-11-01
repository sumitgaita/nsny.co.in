using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface IBranchStudentBindManager
    {
        //List<Project> GetAllProducts();
        //List<Project> GetAllHiddenProjects();
        bool CreateBranchStudentBind(BranchStudentBind branchStudentBind);
        List<BranchPaymentCollection> GetBranchPaymentCollection(int branchId);
        int PaymenCount(int branchId, string dt);
        bool CreatePaymentollection(BranchPaymentCollection branchPaymentCollection);
        bool PaymentLastUpdate(BranchPaymentCollection branchPaymentCollection);
        List<BranchPaymentCollection> GetRecivedPrint(string stid);
        List<BranchPaymentCollection> GetBranchPaymenteraning(int branchId, string fromdate, string todate);
        List<BranchPaymentCollection> GetStuRegistrationList(int branchId, string fromdate, string todate);
        List<BranchPaymentCollection> GetAdminStudentIcard(int branchId, string fromdate, string todate);
        List<BranchPaymentCollection> GetCourseBindList(string stid);
        bool StudentCourseBindUpdate(BranchStudentBind branchStudentBind);
        //bool UpdateProject(Project project);
        //Project ProjectDetails(Project projectdetails);
        //bool ShowProject(Project projects);
        //bool HideProject(Project projects);
        //List<Project> GetAdminUserProjects(Project loginId);
        //List<Project> GetAdminUserHiddenProjects(Project loginId);
        //List<Project> AdminUserProjectList(Project loginId);
        // Project ProjectNameClientName(Project pro);
    }
}