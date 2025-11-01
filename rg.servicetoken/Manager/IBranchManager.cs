using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface IBranchManager
    {
        //List<Project> GetAllProducts();
        //List<Project> GetAllHiddenProjects();
        bool CreateBranch(Branch branch);
        bool UpdateBranch(Branch branch);
        bool DeleteBranch(Branch per);
        List<Branch> GetAllBranch();
        int CurrntBranchId();
        bool CreateBranchNotification(Notification notification);
        List<Notification> GetBranchNotification(int bid);
        List<Notification> GetAllNotification();
        bool DeleteNotification(Notification ids);
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