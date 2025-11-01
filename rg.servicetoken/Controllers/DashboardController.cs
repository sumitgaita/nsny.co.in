using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        private readonly IDashboardManager _dashboardManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public DashboardController(IHttpResponseMessage httploginResponseMessage, IDashboardManager dashboardManager)
        {
            _httpResponseMessage = httploginResponseMessage;
            _dashboardManager = dashboardManager;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                Dashboard loginDetails = new Dashboard();
                loginDetails.NumberofStudents = _dashboardManager.NumberofStudents();
                loginDetails.NumberofCourse = _dashboardManager.NumberofCourse();
                loginDetails.NumberofBranche = _dashboardManager.NumberofBranche();
                return _httpResponseMessage.ReturnOk(loginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(string Center_code, string likestr)
        {
            try
            {
                Dashboard loginDetails = new Dashboard();
                loginDetails.NumberofStudents = _dashboardManager.NumberofBranchStudents(Center_code, likestr);
                loginDetails.NumberofCourse = _dashboardManager.NumberofCourse();
                return _httpResponseMessage.ReturnOk(loginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //[HttpGet]
        //[Route("")]
        //public HttpResponseMessage NumberofCourse()
        //{
        //    try
        //    {
        //        Dashboard loginDetails = _dashboardManager.NumberofCourse();
        //        return _httpResponseMessage.ReturnOk(loginDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //[HttpGet]
        //[Route("")]
        //public HttpResponseMessage NumberofStudents()
        //{
        //    try
        //    {
        //        Dashboard loginDetails = _dashboardManager.NumberofBranche();
        //        return _httpResponseMessage.ReturnOk(loginDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //[Route("")]
        //public HttpResponseMessage Get(int loginId)
        //{
        //    try
        //    {
        //        User det = new User() { LoginId = loginId };
        //        User userDetails = _loginManager.UserDetails(det);
        //        return _httpResponseMessage.ReturnOk(userDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[Route("")]
        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        System.Collections.Generic.List<User> users = _loginManager.GetAllUsers();
        //        return _httpResponseMessage.ReturnOk(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpPost]
        //[Route("")]
        //public HttpResponseMessage CreateUser([FromBody] JObject jsonData)
        //{
        //    try
        //    {
        //        User users = jsonData.ToObject<User>();
        //        bool response = _loginManager.CreateUser(users);
        //        return _httpResponseMessage.ReturnOk(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //[HttpPut]
        //[Route("update")]
        //public HttpResponseMessage UpdateUser([FromBody] JObject jsonData)
        //{
        //    User users = jsonData.ToObject<User>();
        //    bool response = _loginManager.UpdateUser(users);
        //    return _httpResponseMessage.ReturnOk(response);
        //}


        //[HttpDelete]
        //[Route("")]
        //public HttpResponseMessage Delete(int loginId)
        //{
        //    User det = new User() { LoginId = loginId };
        //    bool response = _loginManager.DeleteUser(det);
        //    return _httpResponseMessage.ReturnOk(response);
        //}

    }
}