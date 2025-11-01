using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class ProjectManager: IProjectManager
    {
        public List<Project> GetAllProducts()
        {
            var data = new ProjectData();

            return data.GetAllProjects();
        }
        public List<Project> GetAllHiddenProjects()
        {
            var data = new ProjectData();

            return data.GetAllHiddenProjects();
        }

        public bool CreateProject(Project projects)
        {
            var data = new ProjectData();
              data.CreateProject(projects);
            return true;
        }
        public bool UpdateProject(Project project)
        {
            var data = new ProjectData();
            return data.UpdateProject(project);

        }
        public Project ProjectDetails(Project projectdetails)
        {
            var data = new ProjectData();

            return data.ProjectDetails(projectdetails);
        }

        public bool ShowProject(Project projects)
        {
            var data = new ProjectData();

            return data.ShowProject(projects);
        }

        public bool HideProject(Project projects)
        {
            var data = new ProjectData();

            return data.HideProject(projects);
        }

        public List<Project> GetAdminUserProjects(Project loginId)
        {
            var data = new ProjectData();
            return data.GetAdminUserProjects(loginId);
        }

        public List<Project> GetAdminUserHiddenProjects(Project loginId)
        {
            var data = new ProjectData();
            return data.GetAdminUserHiddenProjects(loginId);
        }

        public List<Project> AdminUserProjectList(Project loginId)
        {
            var data = new ProjectData();
            return data.AdminUserProjectList(loginId);
        }

        //public Project ProjectNameClientName(Project pro)
            //{
            //    var data = new ProjectData();

            //    return data.ProjectNameClientName(pro);
            //}
        }
}