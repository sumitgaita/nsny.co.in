using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly IStudentManager _studentManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public StudentController(IHttpResponseMessage httpResponseMessage, IStudentManager studentManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _studentManager = studentManager;

        }
        [Route("")]
        public HttpResponseMessage Get(string nssy_code)
        {
            System.Collections.Generic.List<Student> student = _studentManager.GetStudent(nssy_code);

            return _httpResponseMessage.ReturnOk(student);
        }

        [Route("")]
        public HttpResponseMessage Get(string center_code, int name)
        {
            System.Collections.Generic.List<Student> student = _studentManager.GetByCenterCodeStudent(center_code);
            return _httpResponseMessage.ReturnOk(student);
        }

        [Route("")]
        public HttpResponseMessage Get(int branchId)
        {
            System.Collections.Generic.List<BranchViewStudent> student = _studentManager.GetBranchViewStudent(branchId);
            return _httpResponseMessage.ReturnOk(student.OrderByDescending(o => o.Stid));
        }
        //[Route("")]
        ////[AllowAnonymous]
        //public HttpResponseMessage Get(int projectId)
        //{
        //    try
        //    {
        //        var det = new Project() { ProjectId = projectId };

        //        var resourceDetails = _projectManager.ProjectDetails(det);
        //        return _httpResponseMessage.ReturnOk(resourceDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}
        [Route("")]
        public HttpResponseMessage Get(string centercode, string nssycode)
        {
            try
            {
                Student det = new Student() { Center_code = centercode, NSSY_code = nssycode };
                int countCostCode = _studentManager.BranchStudentRegisCount(det);
                return _httpResponseMessage.ReturnOk(countCostCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateStudent([FromBody] JObject jsonData)
        {

            Student student = jsonData.ToObject<Student>();
            int response = _studentManager.CreateStudent(student);
            return _httpResponseMessage.ReturnOk(response);

        }


        //// PUT: api/Project/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateStudent([FromBody] JObject jsonData)
        {
            Student student = jsonData.ToObject<Student>();
            bool response = _studentManager.UpdateStudent(student);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int studentId)
        {
            Student det = new Student() { Id = studentId };
            bool response = _studentManager.DeleteStudent(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }


}
