using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IProjectManager
    {
        List<Project> GetAllProducts();
        List<Project> GetAllHiddenProjects();
        bool CreateProject(Project projects);
        bool UpdateProject(Project project);
        Project ProjectDetails(Project projectdetails);
        bool ShowProject(Project projects);
        bool HideProject(Project projects);
        List<Project> GetAdminUserProjects(Project loginId);
        List<Project> GetAdminUserHiddenProjects(Project loginId);
        List<Project> AdminUserProjectList(Project loginId);
        // Project ProjectNameClientName(Project pro);
    }
}