using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/Resource")]
    public class ResourceController : ApiController
    {
        private readonly IResourceManager _resourceManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public ResourceController(IHttpResponseMessage httpResponseMessage, IResourceManager resourceManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _resourceManager = resourceManager;
        }

        [Route("")]
        public HttpResponseMessage Get(int projectId)
        {
            try
            {
                Resource det = new Resource() { ProjectId = projectId };
                System.Collections.Generic.List<Resource> resourceDetails = _resourceManager.ResourceDetails(det);
                return _httpResponseMessage.ReturnOk(resourceDetails.OrderBy(o => o.CreateDate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage GetResourceName(int projectId, string resourceName)
        {
            try
            {
                ResourceNameArray det = new ResourceNameArray() { ProjectId = projectId, ResourceName = resourceName };
                System.Collections.Generic.List<ResourceNameArray> resourceDetails = _resourceManager.GetResourceName(det);
                return _httpResponseMessage.ReturnOk(resourceDetails);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage GetResource(int projectId, int ipage)
        {
            try
            {
                Resource det = new Resource() { ProjectId = projectId };
                System.Collections.Generic.List<Resource> resourceDetails = _resourceManager.ResourceDetails(det, ipage, out int totalRecords, out decimal totalCost);
                return
                    _httpResponseMessage.ReturnOk(
                        new { resources = resourceDetails.OrderBy(o => o.CreateDate), records = totalRecords, costs = totalCost });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int projectId, int costcodeId)
        {
            try
            {
                Resource det = new Resource() { ProjectId = projectId, CostCode = costcodeId };
                System.Collections.Generic.List<Resource> resourRtpceDetails = _resourceManager.CostCalclationCostCoderpt(det);
                return _httpResponseMessage.ReturnOk(resourRtpceDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int projectId, int costcodeId, DateTime searchDate)
        {
            try
            {
                Resource det = new Resource() { ProjectId = projectId, CostCode = costcodeId, CreateDate = searchDate };
                System.Collections.Generic.List<Resource> costCodeWiseDetails = _resourceManager.CostCodeWiseResource(det);
                return _httpResponseMessage.ReturnOk(costCodeWiseDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int resourseId, string optional = "")
        {
            try
            {
                Resource det = new Resource() { ResourceId = resourseId };
                Resource resourceDetails = _resourceManager.GetResourceDetails(det);
                return _httpResponseMessage.ReturnOk(resourceDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int resourseId, bool viewCostStatus)
        {
            try
            {
                Resource det = new Resource() { ResourceId = resourseId, CheckStaus = viewCostStatus };
                bool resourceStatus = _resourceManager.UpdateViewCostStatus(det);
                return _httpResponseMessage.ReturnOk(resourceStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int projectId, DateTime deleteDate)
        {
            try
            {
                Resource det = new Resource() { ProjectId = projectId, CreateDate = deleteDate };
                bool resourceDetails = _resourceManager.DeleteAllResource(det);
                return _httpResponseMessage.ReturnOk(resourceDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateResource([FromBody] JObject jsonData)
        {
            try
            {
                Resource res = jsonData.ToObject<Resource>();
                bool response = _resourceManager.CreateResource(res);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateResource([FromBody] JObject jsonData)
        {
            Resource res = jsonData.ToObject<Resource>();
            bool response = _resourceManager.UpdateResource(res);
            if (response)
            {
                Resource total = _resourceManager.GetTotalCost(res);
                return _httpResponseMessage.ReturnOk(total);
            }
            return _httpResponseMessage.ReturnOk(response);
        }

        
        [HttpDelete]
        [Route("")]
        public void Delete(int resourseId)
        {
            Resource det = new Resource() { ResourceId = resourseId };
            bool response = _resourceManager.DeleteResource(det);
        }
    }
}
