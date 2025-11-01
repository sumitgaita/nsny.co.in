using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class CommissionPayManager : ICommissionPayManager
    {

        public bool CreateCommissionPay(CommissionPay commissionPay)
        {
            CommissionPayData data = new CommissionPayData();
            return data.CreateCommissionPay(commissionPay);
        }

        public int PaymentGeneratedforHQ(int branchId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.PaymentGeneratedforHQ(branchId);
        }

        public int PaymentCompletedtoHQ(int branchId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.PaymentCompletedtoHQ(branchId);
        }
        public int PaymentRemaining(int branchId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.PaymentRemaining(branchId);
        }
        public System.Collections.Generic.List<PaymentStatus> GetPaymentSendtoHQ(int branchId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetPaymentSendtoHQ(branchId);
        }
        public List<PaymentStatus> GetPaymentGeneratedatBranch(int branchId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetPaymentGeneratedatBranch(branchId);
        }
        public int AdminPaymentGeneratedforHQ()
        {
            CommissionPayData data = new CommissionPayData();
            return data.AdminPaymentGeneratedforHQ();
        }
        public int AdminPaymentCompletedtoHQ()
        {
            CommissionPayData data = new CommissionPayData();
            return data.AdminPaymentCompletedtoHQ();
        }
        public int AdminPaymentRemaining()
        {
            CommissionPayData data = new CommissionPayData();
            return data.AdminPaymentRemaining();
        }
        public List<PaymentStatus> GetAdminPaymentGeneratedatBranch()
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetAdminPaymentGeneratedatBranch();
        }
        public List<PaymentStatus> GetAdminPaymentSendHQ()
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetAdminPaymentSendHQ();
        }
        public bool PaymentUpdate(int paymentId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.PaymentUpdate(paymentId);
        }
        public bool PaymentUpdatestatus(int paymentId)
        {
            CommissionPayData data = new CommissionPayData();
            return data.PaymentUpdatestatus(paymentId);
        }
        public int GetBranchOfficeEarning(int branchId, string fromdate, string todate)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetBranchOfficeEarning(branchId, fromdate, todate);
        }
        public int GetHQOfficeEarning(int branchId, string fromdate, string todate)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetHQOfficeEarning(branchId, fromdate, todate);
        }
        public int GetTotalEarning(int branchId, string fromdate, string todate)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetTotalEarning(branchId, fromdate, todate);
        }
        public List<BranchPaymentCollection> GetViewEarningDetails(int branchId, string fromdate, string todate)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetViewEarningDetails(branchId, fromdate, todate);
        }
        public bool UpdateCourseBindPayment(CommissionPay commissionPay)
        {
            CommissionPayData data = new CommissionPayData();
            return data.UpdateCourseBindPayment(commissionPay);
        }
        public List<BranchPaymentCollection> GetStudentPaymentDetails(string nssy_code)
        {
            CommissionPayData data = new CommissionPayData();
            return data.GetStudentPaymentDetails(nssy_code);
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