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
    //[Authorize]
    [RoutePrefix("api/Report")]
    public class ReportController : ApiController
    {
        private readonly IStudentManager _studentManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public ReportController(IHttpResponseMessage httpResponseMessage, IStudentManager studentManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _studentManager = studentManager;

        }
        [Route("")]
        public HttpResponseMessage Get(string studentId)
        {

            return null;
        }

        

      
       

       
    }


}
