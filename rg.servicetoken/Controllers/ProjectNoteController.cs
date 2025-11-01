using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/ProjectNote")]
    public class ProjectNoteController : ApiController
    {
        private readonly IProjectNoteManager _projectNoteManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public ProjectNoteController(IHttpResponseMessage httpResponseMessage, IProjectNoteManager projectNoteManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _projectNoteManager = projectNoteManager;
        }

        [Route("")]
        public HttpResponseMessage Get(int projectId, DateTime searchDate)
        {
            try
            {
                ProjectNote det = new ProjectNote() { ProjectId = projectId, CreateDate = searchDate };
                ProjectNote proNoteDetails = _projectNoteManager.ProjectNoteDetails(det);
                return _httpResponseMessage.ReturnOk(proNoteDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateUser([FromBody] JObject jsonData)
        {
            try
            {
                ProjectNote pn = jsonData.ToObject<ProjectNote>();
                bool response = _projectNoteManager.ProjectNoteWeather(pn);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
