using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace rg.service.Controllers
{

    [RoutePrefix("api/Upload")]
    public class UploadImageController : ApiController
    {
        private readonly IStudentManager _studentManager;
        private readonly ICommissionPayManager _commissionPay;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public UploadImageController(IHttpResponseMessage httpResponseMessage, IStudentManager studentManager, ICommissionPayManager commissionPay)
        {
            _httpResponseMessage = httpResponseMessage;
            _studentManager = studentManager;
            _commissionPay = commissionPay;

        }

        [Route("")]
        public HttpResponseMessage Get(string name, string nssy_code)
        {
            System.Collections.Generic.List<Student> student = _studentManager.GetStudentVerification(name,nssy_code);
            return _httpResponseMessage.ReturnOk(student);
        }

        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get(string studentId)
        {
            try
            {
                var paymentList = _commissionPay.GetStudentPaymentDetails(studentId);
                return _httpResponseMessage.ReturnOk(paymentList);
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
                    string filePath = HttpContext.Current.Server.MapPath("~/Files/" + pic+".jpg");
                    postedFile.SaveAs(filePath);
                }
            }

            bool response1 = _studentManager.UpdateStudentImageName(student);
            return _httpResponseMessage.ReturnOk(response1);
        }

    }
}
