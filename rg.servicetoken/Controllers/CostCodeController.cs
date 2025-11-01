using System;
using System.Collections.Generic;
using System.Linq;
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
    [RoutePrefix("api/CostCode")]
    public class CostCodeController : ApiController
    {
        private readonly ICostCodeManager _costCodeManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public CostCodeController(IHttpResponseMessage httpResponseMessage, ICostCodeManager costCodeManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _costCodeManager = costCodeManager;

        }
        // GET: api/CostCode
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CostCode/5
        [Route("")]
        public HttpResponseMessage Get(int projectId)
        {
            try
            {
                var det = new CostCode() { ProjectId = projectId };

                var costCodeDetails = _costCodeManager.CostCodeDetails(det);
                return _httpResponseMessage.ReturnOk(costCodeDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        [Route("")]
        public HttpResponseMessage Get(int costCodeId, string optional = "")
        {
            try
            {
                var det = new CostCode() { CostCodeId = costCodeId };

                var costCodeEditDetails = _costCodeManager.CostCodeEditDetails(det);
                return _httpResponseMessage.ReturnOk(costCodeEditDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        [Route("")]
        public HttpResponseMessage Get(int projectId, DateTime searchDate)
        {
            try
            {
                var det = new CostCode() { ProjectId = projectId, CostCodeCreateDate = searchDate };

                var countCostCode = _costCodeManager.CountCostCode(det);
                return _httpResponseMessage.ReturnOk(countCostCode.OrderBy(x=>x.CostCodeName));
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        // POST: api/CostCode
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateCostCode([FromBody] JObject jsonData)
        {

            try
            {
                CostCode cc = jsonData.ToObject<CostCode>();
                var response = _costCodeManager.CreateCostCode(cc);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // PUT: api/CostCode/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateCostCode([FromBody] JObject jsonData)
        {
            CostCode cc = jsonData.ToObject<CostCode>();
            var response = _costCodeManager.UpdateCostCode(cc);
            return _httpResponseMessage.ReturnOk(response);
        }

        // DELETE: api/CostCode/5
        [HttpDelete]
        //[Route("{loginId:int}")]
        [Route("")]
        public HttpResponseMessage Delete(int costcodeId)
        {
            var det = new CostCode() { CostCodeId = costcodeId };
            var response = _costCodeManager.DeleteCostCode(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }
}
