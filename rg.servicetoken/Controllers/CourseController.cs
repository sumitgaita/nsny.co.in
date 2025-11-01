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
    [RoutePrefix("api/Course")]
    public class ProjectController : ApiController
    {
        private readonly ICourseManager _courseManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public ProjectController(IHttpResponseMessage httpResponseMessage, ICourseManager courseManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _courseManager = courseManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Course> course = _courseManager.GetAllCourse();
            return _httpResponseMessage.ReturnOk(course);
        }

        [Route("")]
        public HttpResponseMessage Get(string active)
        {
            System.Collections.Generic.List<Course> course = _courseManager.GetAllActiveCourse();
            return _httpResponseMessage.ReturnOk(course);
        }

        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get(int couseId)
        {
            try
            {
                Course det = new Course() { Id = couseId };
                System.Collections.Generic.List<Course> courseDetails = _courseManager.GetByIdCourse(det);
                return _httpResponseMessage.ReturnOk(courseDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateCourse([FromBody] JObject jsonData)
        {

            Course course = jsonData.ToObject<Course>();
            bool response = _courseManager.CreateCourse(course);
            return _httpResponseMessage.ReturnOk(response);


        }


        //// PUT: api/Project/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateCourse([FromBody] JObject jsonData)
        {
            Course course = jsonData.ToObject<Course>();
            bool response = _courseManager.UpdateCourse(course);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int courseId)
        {
            Course det = new Course() { Id = courseId };
            bool response = _courseManager.DeleteCourse(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }


}
