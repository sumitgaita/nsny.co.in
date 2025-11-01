using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface ICourseManager
    {
        //List<Project> GetAllProducts();
        //List<Project> GetAllHiddenProjects();
        bool CreateCourse(Course course);
        List<Course> GetAllCourse();
        bool UpdateCourse(Course course);
        bool DeleteCourse(Course per);
        List<Course> GetByIdCourse(Course courses);
        List<Course> GetAllActiveCourse();
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