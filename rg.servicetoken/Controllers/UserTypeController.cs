using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/UserType")]
    public class UserTypeController : ApiController
    {
        private readonly IUserTypeManager _userTypeManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public UserTypeController(IHttpResponseMessage httploginResponseMessage, IUserTypeManager userTypeManager)
        {
            _httpResponseMessage = httploginResponseMessage;
            _userTypeManager = userTypeManager;
        }

        [Route("")]
        public HttpResponseMessage Get(int loginId)
        {
            try
            {
                UserType det = new UserType() { LoginId = loginId };
                UserType userTypeDetails = _userTypeManager.UserTypeDetails(det);
                return _httpResponseMessage.ReturnOk(userTypeDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
