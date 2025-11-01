using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class WalletManager : IWalletManager
    {
        public List<Branch> GetAllWalletBranch()
        {
            WalletData data = new WalletData();
            return data.GetAllWalletBranch();
        }
        //public List<Project> GetAllHiddenProjects()
        //{
        //    var data = new ProjectData();

        //    return data.GetAllHiddenProjects();
        //}

        public bool CreateWallet(Wallet wallet)
        {
            bool isWalletCreated = false;
            int WalletId = 0;
            WalletData data = new WalletData();
            isWalletCreated = data.CreateWallet(wallet);
            if (isWalletCreated)
            {
                WalletId = data.CurrntWalletId();
                if (WalletId > 0)
                {
                    wallet.WalletId = WalletId;
                    isWalletCreated = data.CreateWalletDetails(wallet);
                }
            }
            return isWalletCreated;
        }

        //public bool UpdateBranch(Branch branch)
        //{
        //    BranchData data = new BranchData();
        //    return data.UpdateBranch(branch);

        //}

        //public bool DeleteBranch(Branch branch)
        //{
        //    BranchData data = new BranchData();
        //    return data.DeleteBranch(branch);

        //}

        //public int CurrntBranchId()
        //{
        //    BranchData data = new BranchData();
        //    return data.CurrntBranchId();
        //}
        //public bool CreateBranchNotification(Notification notification)
        //{
        //    BranchData data = new BranchData();
        //    return data.CreateBranchNotification(notification);
        //}
        public List<Wallet> GetBranchWallet(int branchId)
        {
            WalletData data = new WalletData();
            return data.GetBranchWallet(branchId);

        }
        public List<Wallet> GetBranchWalletHistoryDetails(int branchId, string paymentNote)
        {
            WalletData data = new WalletData();
            return data.GetBranchWalletHistoryDetails(branchId, paymentNote);
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