using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Resources;
using System.Web.Http;

namespace rg.service.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Notification")]
    public class NotificationController : ApiController
    {
        private readonly IBranchManager _branchManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public NotificationController(IHttpResponseMessage httpResponseMessage, IBranchManager branchManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _branchManager = branchManager;

        }

        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Notification> notification = _branchManager.GetAllNotification();
            return _httpResponseMessage.ReturnOk(notification);
        }

        [Route("")]
        public HttpResponseMessage Get(int bid)
        {
            System.Collections.Generic.List<Notification> branchNotification = _branchManager.GetBranchNotification(bid);
            return _httpResponseMessage.ReturnOk(branchNotification);
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

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateBranch([FromBody] JObject jsonData)
        {
            try
            {
                Notification notification = jsonData.ToObject<Notification>();
                bool response = _branchManager.CreateBranchNotification(notification);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        
        //// PUT: api/Project/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateBranch([FromBody] JObject jsonData)
        {
            Branch branch = jsonData.ToObject<Branch>();
            var response = _branchManager.UpdateBranch(branch);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int branchId)
        {
            var det = new Branch() { Id = branchId };
            var response = _branchManager.DeleteBranch(det);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("deleteNotification")]
        public HttpResponseMessage DeleteNotification(int id)
        {
            var det = new Notification() { Id = id };
            var response = _branchManager.DeleteNotification(det);
            return _httpResponseMessage.ReturnOk(response);
        }

    }


}
