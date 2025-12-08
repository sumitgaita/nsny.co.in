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
    [RoutePrefix("api/Center")]
    public class CenterController : ApiController
    {
        private readonly ICenterManager _centerManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public CenterController(IHttpResponseMessage httpResponseMessage, ICenterManager centerManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _centerManager = centerManager;

        }
       
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetCenter(int bid)
        {
            var branch = _centerManager.GetBranchCenter(bid);
            return _httpResponseMessage.ReturnOk(branch);
        }

        [HttpGet]
        [Route("currentcenter")]
        public HttpResponseMessage Get(int currentId)
        {
            int branch = _centerManager.CurrntCenterId();
            return _httpResponseMessage.ReturnOk(branch);
        }
       
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateCenter([FromBody] JObject jsonData)
        {
            try
            {
                Branch branch = jsonData.ToObject<Branch>();
                bool response = _centerManager.CreateCenter(branch);
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
        public HttpResponseMessage UpdateCenter([FromBody] JObject jsonData)
        {
            Branch branch = jsonData.ToObject<Branch>();
            var response = _centerManager.UpdateCenter(branch);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int branchId)
        {
            var det = new Branch() { Id = branchId };
            var response = _centerManager.DeleteCenter(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }


}
