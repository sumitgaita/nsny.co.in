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
    [RoutePrefix("api/MasterCode")]
    public class MasterCodeController : ApiController
    {
        private readonly IMasterCodeManager _mastercodeManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public MasterCodeController(IHttpResponseMessage httpResponseMessage, IMasterCodeManager mastercodeManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _mastercodeManager = mastercodeManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Master_Code> mastercode = _mastercodeManager.GetAllMasterCode();
            return _httpResponseMessage.ReturnOk(mastercode);
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateMasterCode([FromBody] JObject jsonData)
        {
            try
            {
                Master_Code masterCode = jsonData.ToObject<Master_Code>();
                bool response = _mastercodeManager.CreateMasterCode(masterCode);
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
        public HttpResponseMessage UpdateMasterCode([FromBody] JObject jsonData)
        {
            Master_Code masterCode = jsonData.ToObject<Master_Code>();
            var response = _mastercodeManager.UpdateMasterCode(masterCode);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int mastercodeid)
        {
            var det = new Master_Code() { Id = mastercodeid };
            var response = _mastercodeManager.DeleteMasterCode(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }


}
