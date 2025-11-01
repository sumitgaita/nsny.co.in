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
    [RoutePrefix("api/Project")]  
    public class ProjectController : ApiController
    {
        private readonly IProjectManager _projectManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public ProjectController(IHttpResponseMessage httpResponseMessage, IProjectManager projectManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _projectManager = projectManager;

        }
        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get()
        {
            var projects = _projectManager.GetAllProducts();
            return _httpResponseMessage.ReturnOk(projects);
        }
        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get(int projectId)
        {
            try
            {
                var det = new Project() { ProjectId = projectId };

                var resourceDetails = _projectManager.ProjectDetails(det);
                return _httpResponseMessage.ReturnOk(resourceDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
       
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateProjects([FromBody] JObject jsonData)
        {

            Project project = jsonData.ToObject<Project>();
            var response = _projectManager.CreateProject(project);
            return _httpResponseMessage.ReturnOk(response);


        }
        // PUT: api/Project/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateProjects([FromBody] JObject jsonData)
        {
            Project project = jsonData.ToObject<Project>();
            var response = _projectManager.UpdateProject(project);
            return _httpResponseMessage.ReturnOk(response);
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }
    }


}
