using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class BranchManager : IBranchManager
    {
        public List<Branch> GetAllBranch()
        {
            BranchData data = new BranchData();
            return data.GetAllBranch();
        }
        //public List<Project> GetAllHiddenProjects()
        //{
        //    var data = new ProjectData();

        //    return data.GetAllHiddenProjects();
        //}

        public bool CreateBranch(Branch branch)
        {
            BranchData data = new BranchData();
            return data.CreateBranch(branch);
        }

        public bool UpdateBranch(Branch branch)
        {
            BranchData data = new BranchData();
            return data.UpdateBranch(branch);

        }

        public bool DeleteBranch(Branch branch)
        {
            BranchData data = new BranchData();
            return data.DeleteBranch(branch);

        }

        public int CurrntBranchId()
        {
            BranchData data = new BranchData();
            return data.CurrntBranchId();
        }
        public bool CreateBranchNotification(Notification notification)
        {
            BranchData data = new BranchData();
            return data.CreateBranchNotification(notification);
        }
        public List<Notification> GetBranchNotification(int bid)
        {
            BranchData data = new BranchData();
            return data.GetBranchNotification(bid);

        }
        public List<Notification> GetAllNotification()
        {
            BranchData data = new BranchData();
            return data.GetAllNotification();
        }
        public bool DeleteNotification(Notification ids)
        {
            BranchData data = new BranchData();
            return data.DeleteNotification(ids);
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