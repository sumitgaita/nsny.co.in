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
    [RoutePrefix("api/Branch")]
    public class BranchController : ApiController
    {
        private readonly IBranchManager _branchManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public BranchController(IHttpResponseMessage httpResponseMessage, IBranchManager branchManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _branchManager = branchManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Branch> branch = _branchManager.GetAllBranch();
            return _httpResponseMessage.ReturnOk(branch);
        }

        [Route("")]
        public HttpResponseMessage Get(int currentId)
        {
            int branch = _branchManager.CurrntBranchId();
            return _httpResponseMessage.ReturnOk(branch);
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
                Branch branch = jsonData.ToObject<Branch>();
                bool response = _branchManager.CreateBranch(branch);
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
    }


}
