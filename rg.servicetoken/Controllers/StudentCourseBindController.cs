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
    [RoutePrefix("api/StudentCourseBind")]
    public class StudentCourseBindController : ApiController
    {
        private readonly IBranchStudentBindManager _branchStudentBind;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public StudentCourseBindController(IHttpResponseMessage httpResponseMessage, IBranchStudentBindManager branchStudentBind)
        {
            _httpResponseMessage = httpResponseMessage;
            _branchStudentBind = branchStudentBind;

        }
        //[Route("")]
        //public HttpResponseMessage Get()
        //{
        //    System.Collections.Generic.List<Course> projects = _courseManager.GetAllCourse();
        //    return _httpResponseMessage.ReturnOk(projects);
        //}
        //[Route("")]
        //public HttpResponseMessage Get(int branchId)
        //{
        //    try
        //    {
        //        System.Collections.Generic.List<BranchPaymentCollection> resourceDetails = _branchStudentBind.GetBranchPaymentCollection(branchId);
        //        return _httpResponseMessage.ReturnOk(resourceDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //[Route("")]
        //public HttpResponseMessage Get(int branchId,string fromdate,string todate)
        //{
        //    try
        //    {
        //        System.Collections.Generic.List<BranchPaymentCollection> resourceDetails = _branchStudentBind.GetBranchPaymenteraning(branchId, fromdate, todate);
        //        return _httpResponseMessage.ReturnOk(resourceDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        [Route("")]
        public HttpResponseMessage Get(string stid)
        {
            try
            {
                System.Collections.Generic.List<BranchPaymentCollection> printDetails = _branchStudentBind.GetCourseBindList(stid);
                return _httpResponseMessage.ReturnOk(printDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[Route("")]
        //public HttpResponseMessage Get(int branchId, string dt)
        //{
        //    try
        //    {
        //        int count = _branchStudentBind.PaymenCount(branchId, dt);
        //        return _httpResponseMessage.ReturnOk(count);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //[HttpPost]
        //[Route("")]
        //public HttpResponseMessage CreateCourse([FromBody] JObject jsonData)
        //{

        //    BranchStudentBind course = jsonData.ToObject<BranchStudentBind>();
        //    bool response = _branchStudentBind.CreateBranchStudentBind(course);
        //    return _httpResponseMessage.ReturnOk(response);


        //}


        //// PUT: api/Project/5
        //[HttpPut]
        //[Route("update")]
        //public HttpResponseMessage UpdateCourse([FromBody] JObject jsonData)
        //{
        //    Course course = jsonData.ToObject<Course>();
        //    var response = _courseManager.UpdateCourse(course);
        //    return _httpResponseMessage.ReturnOk(response);
        //}

        //[HttpDelete]
        //[Route("")]
        //public HttpResponseMessage Delete(int courseId)
        //{
        //    var det = new Course() { Id = courseId };
        //    var response = _courseManager.DeleteCourse(det);
        //    return _httpResponseMessage.ReturnOk(response);
        //}
    }


}
