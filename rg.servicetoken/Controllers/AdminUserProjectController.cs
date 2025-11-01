using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/AdminUserProject")]
    public class AdminUserProjectController : ApiController
    {
        private readonly IProjectManager _projectManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public AdminUserProjectController(IHttpResponseMessage httpResponseMessage, IProjectManager projectManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _projectManager = projectManager;

        }
       
        [Route("")]
        public HttpResponseMessage Get(int loginId)
        {
            var det = new Project() { LoginId = loginId };
            var projects = _projectManager.GetAdminUserProjects(det);
            return _httpResponseMessage.ReturnOk(projects);
        }
        [Route("")]
        public HttpResponseMessage Get(int loginId, string optional)
        {
            var det = new Project() { LoginId = loginId };
            var projects = _projectManager.AdminUserProjectList(det);
            return _httpResponseMessage.ReturnOk(projects);
        }
        
    }
}
