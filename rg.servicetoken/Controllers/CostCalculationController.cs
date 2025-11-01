using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/CostCalculation")]
    public class CostCalculationController : ApiController
    {
        private readonly ICostCalculationManager _costCalculationManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public CostCalculationController(IHttpResponseMessage httpResponseMessage, ICostCalculationManager costCalculationManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _costCalculationManager = costCalculationManager;

        }
        // GET: api/CostCalculation
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
               var  projectName = _costCalculationManager.GetAllProjects();
                return _httpResponseMessage.ReturnOk(projectName);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        // GET: api/CostCalculation/5
        [Route("")]
        public HttpResponseMessage Get(int projectId,DateTime searchDate)
        {
            try
            {
                var det = new CostCalculation() { ProjectId = projectId,SearchDate = searchDate };

                var projectMonthWiseDetails = _costCalculationManager.ProjectMonthWiseDetails(det);
                return _httpResponseMessage.ReturnOk(projectMonthWiseDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        [Route("")]
        public HttpResponseMessage Get(int projectId)
        {
            try
            {
                var det = new CostCalculation() { ProjectId = projectId };

                var projectWiseDetails = _costCalculationManager.PojectwiseDetails(det);
                return _httpResponseMessage.ReturnOk(projectWiseDetails.OrderBy(o=>o.CreateDate));
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        [Route("")]
        public HttpResponseMessage Get(int projectId, string optional)
        {
            try
            {
                var det = new CostCalculation() { ProjectId = projectId };

                var costCodeDetails = _costCalculationManager.PojectwiseCostCodeDetails(det);
                return _httpResponseMessage.ReturnOk(costCodeDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        [Route("")]
        public HttpResponseMessage Get(DateTime searchStartDate, DateTime searchDate)
        {
            try
            {
                var det = new CostCalculation() { SearchStartDate = searchStartDate, SearchDate = searchDate };

                var monthInBetweenDetails = _costCalculationManager.MonthInBeteenDetails(det);
                return _httpResponseMessage.ReturnOk(monthInBetweenDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        // POST: api/CostCalculation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CostCalculation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CostCalculation/5
        public void Delete(int id)
        {
        }
    }
}
