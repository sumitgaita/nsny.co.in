using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class StudentManager : IStudentManager
    {
        public List<Student> GetStudent(string nssy_code)
        {
            StudentData data = new StudentData();
            return data.GetStudent(nssy_code);
        }
        public List<Student> GetByCenterCodeStudent(string center_code)
        {
            StudentData data = new StudentData();
            return data.GetByCenterCodeStudent(center_code);
        }
        public List<BranchViewStudent> GetBranchViewStudent(int branchId)
        {
            StudentData data = new StudentData();
            return data.GetBranchViewStudent(branchId);
        }
        public int BranchStudentRegisCount(Student student)
        {
            StudentData data = new StudentData();
            return data.BranchStudentRegisCount(student);
        }

        public int CreateStudent(Student student)
        {
            int stu = 0;
            StudentData data = new StudentData();
            stu = data.CreateStudent(student);
            return stu;
        }

        public bool UpdateStudent(Student student)
        {
            StudentData data = new StudentData();
            return data.UpdateStudent(student);

        }

        public bool DeleteStudent(Student student)
        {
            StudentData data = new StudentData();
            return data.DeleteStudent(student);

        }

        public bool UpdateStudentImageName(Student student)
        {
            StudentData data = new StudentData();
            return data.UpdateStudentImageName(student);
        }
        public List<Student> GetAdminVerifyStudent()
        {
            StudentData data = new StudentData();
            return data.GetAdminVerifyStudent();
        }
        public List<BranchPaymentCollection> GetStudentIDJdate(string nssy_code)
        {
            StudentData data = new StudentData();
            return data.GetStudentIDJdate(nssy_code);
        }
        public List<Student> GetStudentVerification(string name, string nssy_code)
        {
            StudentData data = new StudentData();
            return data.GetStudentVerification(name, nssy_code);
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