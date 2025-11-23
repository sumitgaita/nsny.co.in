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
    [RoutePrefix("api/UserPermission")]
    public class UserPermissionController : ApiController
    {
        private readonly IUserPermissionManager _userpermissionManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public UserPermissionController(IHttpResponseMessage httpResponseMessage, IUserPermissionManager userpermissionManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _userpermissionManager = userpermissionManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<UserPermission> permission = _userpermissionManager.GetAllPermission();
            return _httpResponseMessage.ReturnOk(permission);
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreatePermission([FromBody] JObject jsonData)
        {
            try
            {
                UserPermission permission = jsonData.ToObject<UserPermission>();
                bool response = _userpermissionManager.CreateUserPermission(permission);
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
        public HttpResponseMessage UpdatePermission([FromBody] JObject jsonData)
        {
            UserPermission permission = jsonData.ToObject<UserPermission>();
            var response = _userpermissionManager.UpdateUserPermission(permission);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int id)
        {
            var det = new UserPermission() { Id = id };
            var response = _userpermissionManager.DeleteUserPermission(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }


}
