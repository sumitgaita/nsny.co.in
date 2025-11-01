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
    [RoutePrefix("api/ChangePassword")]
    public class ChangePasswordController : ApiController
    {

        private readonly IUserManager _loginManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public ChangePasswordController(IHttpResponseMessage httploginResponseMessage, IUserManager loginManager)
        {
            _httpResponseMessage = httploginResponseMessage;
            _loginManager = loginManager;

        }
        [Route("")]
        // GET: api/ChangePassword
        //public HttpResponseMessage Get(string password)
        //{
        //    try
        //    {
        //        var det = new User() { LoginPassword = password };
        //        var loginDetails = _loginManager.ChangePassword(det);
        //        return _httpResponseMessage.ReturnOk(loginDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        // GET: api/ChangePassword/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ChangePassword
        public void Post([FromBody]string value)
        {
        }
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage ChangePassword([FromBody] JObject jsonData)
        {
            User users = jsonData.ToObject<User>();
            var response = _loginManager.ChangePassword(users);
            return _httpResponseMessage.ReturnOk(response);
        }

        // DELETE: api/ChangePassword/5
        public void Delete(int id)
        {
        }
    }
}
