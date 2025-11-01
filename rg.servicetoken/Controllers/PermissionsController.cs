using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/Permissions")]
    public class PermissionsController : ApiController
    {
        private readonly IPermissionsManager _permissionManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public PermissionsController(IHttpResponseMessage httpResponseMessage, IPermissionsManager permissionManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _permissionManager = permissionManager;

        }

        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Permissions> permissions = _permissionManager.GetAllPermissions();
            return _httpResponseMessage.ReturnOk(permissions);
        }

        [Route("")]
        public HttpResponseMessage Get(int permissionId)
        {
            try
            {
                Permissions det = new Permissions() { PermissionId = permissionId };
                Permissions permissionDetails = _permissionManager.EditPermissionDetails(det);
                return _httpResponseMessage.ReturnOk(permissionDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreatePermission([FromBody] JObject jsonData)
        {
            try
            {
                Permissions per = jsonData.ToObject<Permissions>();
                bool response = _permissionManager.CreatePermission(per);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdatePermission([FromBody] JObject jsonData)
        {
            Permissions per = jsonData.ToObject<Permissions>();
            bool response = _permissionManager.UpdatePermission(per);
            return _httpResponseMessage.ReturnOk(response);
        }


        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int permissionId)
        {
            Permissions det = new Permissions() { PermissionId = permissionId };
            bool response = _permissionManager.DeletePermission(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }
}
