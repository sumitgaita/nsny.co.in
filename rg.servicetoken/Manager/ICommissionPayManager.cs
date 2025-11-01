using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface ICommissionPayManager
    {
        //List<Project> GetAllProducts();
        //List<Project> GetAllHiddenProjects();
        bool CreateCommissionPay(CommissionPay commissionPay);
        int PaymentGeneratedforHQ(int branchId);
        int PaymentCompletedtoHQ(int branchId);
        int PaymentRemaining(int branchId);
        List<PaymentStatus> GetPaymentSendtoHQ(int branchId);
        List<PaymentStatus> GetPaymentGeneratedatBranch(int branchId);
        int AdminPaymentGeneratedforHQ();
        int AdminPaymentCompletedtoHQ();
        int AdminPaymentRemaining();
        List<PaymentStatus> GetAdminPaymentGeneratedatBranch();
        List<PaymentStatus> GetAdminPaymentSendHQ();
        bool PaymentUpdate(int paymentId);
        bool PaymentUpdatestatus(int paymentId);
        int GetBranchOfficeEarning(int branchId, string fromdate, string todate);
        int GetHQOfficeEarning(int branchId, string fromdate, string todate);
        int GetTotalEarning(int branchId, string fromdate, string todate);
        List<BranchPaymentCollection> GetViewEarningDetails(int branchId, string fromdate, string todate);
        bool UpdateCourseBindPayment(CommissionPay commissionPay);
        List<BranchPaymentCollection> GetStudentPaymentDetails(string nssy_code);
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