using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/CostsVsBudget")]
    public class CostsVsBudgetController : ApiController
    {
        private readonly ICostsVsBudgetManager _costsvsbudgetManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public CostsVsBudgetController(IHttpResponseMessage httpResponseMessage, ICostsVsBudgetManager costsvsbudgetManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _costsvsbudgetManager = costsvsbudgetManager;

        }
        // GET: api/CostsVsBudget
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("")]
        public HttpResponseMessage Get(int projectId)
        {
            try
            {
                var det = new CostsVsBudget() { ProjectId = projectId };

                var costCodeDetails = _costsvsbudgetManager.CostsVsBudgetDataDetails(det);
                return _httpResponseMessage.ReturnOk(costCodeDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        // POST: api/CostsVsBudget
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CostsVsBudget/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CostsVsBudget/5
        public void Delete(int id)
        {
        }
    }
}
