using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    //[Authorize]
    [RoutePrefix("api/AdminCertificate")]
    public class AdminCertificateController : ApiController
    {
        private readonly IStudentManager _studentManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public AdminCertificateController(IHttpResponseMessage httpResponseMessage, IStudentManager studentManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _studentManager = studentManager;

        }
        [Route("")]
        public HttpResponseMessage Get(string nssy_code)
        {
            System.Collections.Generic.List<BranchPaymentCollection> student = _studentManager.GetStudentIDJdate(nssy_code);

            return _httpResponseMessage.ReturnOk(student);
        }

       
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Student> student = _studentManager.GetAdminVerifyStudent();
            return _httpResponseMessage.ReturnOk(student);
        }

        //[Route("")]
        //public HttpResponseMessage Get(int branchId)
        //{
        //    System.Collections.Generic.List<BranchViewStudent> student = _studentManager.GetBranchViewStudent(branchId);
        //    return _httpResponseMessage.ReturnOk(student);
        //}
        ////[Route("")]
        //////[AllowAnonymous]
        ////public HttpResponseMessage Get(int projectId)
        ////{
        ////    try
        ////    {
        ////        var det = new Project() { ProjectId = projectId };

        ////        var resourceDetails = _projectManager.ProjectDetails(det);
        ////        return _httpResponseMessage.ReturnOk(resourceDetails);
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        throw ex;
        ////    }


        ////}
        //[Route("")]
        //public HttpResponseMessage Get(string centercode, string nssycode)
        //{
        //    try
        //    {
        //        Student det = new Student() { Center_code = centercode, NSSY_code = nssycode };
        //        int countCostCode = _studentManager.BranchStudentRegisCount(det);
        //        return _httpResponseMessage.ReturnOk(countCostCode);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


    }


}
