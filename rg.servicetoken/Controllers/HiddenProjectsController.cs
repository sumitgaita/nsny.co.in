using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/HiddenProjects")]
    public class HiddenProjectsController : ApiController
    {
        private readonly IProjectManager _projectManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public HiddenProjectsController(IHttpResponseMessage httpResponseMessage, IProjectManager projectManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _projectManager = projectManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            var projects = _projectManager.GetAllHiddenProjects();
            return _httpResponseMessage.ReturnOk(projects);
        }
        [Route("")]
        public HttpResponseMessage Get(int loginId)
        {
            var det = new Project() { LoginId = loginId };
            var projects = _projectManager.GetAdminUserHiddenProjects(det);
            return _httpResponseMessage.ReturnOk(projects);
        }
        //[Route("")]
        //public HttpResponseMessage Get(int projectId)
        //{
        //    try
        //    {
        //        var det = new Project() { ProjectId = projectId };

        //        var hideDetails = _projectManager.ResourceDetails(det);
        //        return _httpResponseMessage.ReturnOk(hideDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}
        // GET: api/HiddenProjects/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/HiddenProjects
        [HttpPost]
        [Route("")]
        public HttpResponseMessage ShowProject([FromBody] JObject jsonData)
        {

            try
            {
                Project pro = jsonData.ToObject<Project>();
                var response = _projectManager.ShowProject(pro);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage HideProject([FromBody] JObject jsonData)
        {
            Project pro = jsonData.ToObject<Project>();
            var response = _projectManager.HideProject(pro);
            return _httpResponseMessage.ReturnOk(response);
        }

        // DELETE: api/HiddenProjects/5
        public void Delete(int id)
        {
        }
    }
}
