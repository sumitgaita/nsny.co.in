using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/CostCodeDailyActivity")]
    public class CostCodeDailyActivityController : ApiController
    {
        private readonly ICostCodeManager _costCodeManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public CostCodeDailyActivityController(IHttpResponseMessage httploginResponseMessage, ICostCodeManager costCodeManager)
        {
            _httpResponseMessage = httploginResponseMessage;
            _costCodeManager = costCodeManager;

        }
        // GET: api/CostCodeDailyActivity
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CostCodeDailyActivity/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CostCodeDailyActivity
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateUser([FromBody] JObject jsonData)
        {

            try
            {
                CostCode costCod = jsonData.ToObject<CostCode>();
                var response = _costCodeManager.CreateCostCodeActivity(costCod);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // PUT: api/CostCodeDailyActivity/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CostCodeDailyActivity/5
        public void Delete(int id)
        {
        }
    }
}
