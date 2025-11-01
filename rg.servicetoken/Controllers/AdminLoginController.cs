using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Login")]
    public class AdminLoginController : ApiController
    {
        private readonly IAdminLoginManager _loginManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public AdminLoginController(IHttpResponseMessage httploginResponseMessage, IAdminLoginManager loginManager)
        {
            _httpResponseMessage = httploginResponseMessage;
            _loginManager = loginManager;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(string username, string password, string loginType)
        {
            try
            {
                AdminLogin det = new AdminLogin() { Bname = username, Bpass = password,LoginType= loginType };
                AdminLogin loginDetails = _loginManager.LoginDetails(det);
                return _httpResponseMessage.ReturnOk(loginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("")]
        public HttpResponseMessage Get(int id, string password)
        {
            try
            {

                bool changePass = _loginManager.ChangeBranchPassword(id, password);
                return _httpResponseMessage.ReturnOk(changePass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int id, string username, string password)
        {
            try
            {

                bool changePass = _loginManager.ChangeAdminPassword(id, username, password);
                return _httpResponseMessage.ReturnOk(changePass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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