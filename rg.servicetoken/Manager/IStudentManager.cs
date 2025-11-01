using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface IStudentManager
    {
        //List<Project> GetAllProducts();
        //List<Project> GetAllHiddenProjects();
        int CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student per);
        List<Student> GetStudent(string nssy_code);
        int BranchStudentRegisCount(Student student);
        bool UpdateStudentImageName(Student student);
        List<Student> GetByCenterCodeStudent(string center_code);
        List<BranchViewStudent> GetBranchViewStudent(int branchId);
        List<Student> GetAdminVerifyStudent();
        List<BranchPaymentCollection> GetStudentIDJdate(string nssy_code);
        List<Student> GetStudentVerification(string name, string nssy_code);
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