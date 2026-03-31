using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.IO;
using System.Net.Http;
using System.Web;
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
                if (likestr == "Branch")
                {
                    loginDetails.NumberofCenter = _dashboardManager.NumberofBranchCenter(Center_code);
                }
                return _httpResponseMessage.ReturnOk(loginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("image")]
        public HttpResponseMessage Get(string name, string nssycode, string centercode)
        {
            try
            {
                System.Collections.Generic.List<Student> student = _dashboardManager.GetStudentImage(name, nssycode, centercode);
                return _httpResponseMessage.ReturnOk(student);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            HttpRequest httpRequest = HttpContext.Current.Request;
            Student student = new Student() { };
            //student.Id = Convert.ToInt32(HttpContext.Current.Request.Form["id"]);
            student.NSSY_code = HttpContext.Current.Request.Form["nssycode"];
            string pic = student.NSSY_code.Replace("/", "");
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];
                    student.Fileup_ins = pic + ".jpg";// postedFile.FileName;
                    string filePath = HttpContext.Current.Server.MapPath("~/Files/" + pic + ".jpg");
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    postedFile.SaveAs(filePath);
                }
            }

            // bool response1 = _studentManager.UpdateStudentImageName(student);
            return _httpResponseMessage.ReturnOk(true);
        }


    }
}