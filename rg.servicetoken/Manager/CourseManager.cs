using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class CourseManager : ICourseManager
    {
        public List<Course> GetAllCourse()
        {
            var data = new CourseData();
            return data.GetAllCourse();
        }

        public List<Course> GetAllActiveCourse()
        {
            var data = new CourseData();
            return data.GetAllActiveCourse();
        }

        public List<Course> GetByIdCourse(Course course)
        {
            var data = new CourseData();
            return data.GetByIdCourse(course);
        }
        //public List<Project> GetAllHiddenProjects()
        //{
        //    var data = new ProjectData();

        //    return data.GetAllHiddenProjects();
        //}

        public bool CreateCourse(Course course)
        {
            CourseData data = new CourseData();
            return data.CreateCourse(course);
        }
       
        public bool UpdateCourse(Course course)
        {
            var data = new CourseData();
            return data.UpdateCourse(course);

        }

        public bool DeleteCourse(Course course)
        {
            var data = new CourseData();
            return data.DeleteCourse(course);

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