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
    [RoutePrefix("api/CommissionPay")]
    public class CommissionPayController : ApiController
    {
        private readonly ICommissionPayManager _commissionPay;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public CommissionPayController(IHttpResponseMessage httpResponseMessage, ICommissionPayManager commissionPay)
        {
            _httpResponseMessage = httpResponseMessage;
            _commissionPay = commissionPay;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            dynamic count = new System.Dynamic.ExpandoObject();
            count.Paypen = _commissionPay.AdminPaymentGeneratedforHQ();
            count.Paydone= _commissionPay.AdminPaymentCompletedtoHQ();
            count.Balance= _commissionPay.AdminPaymentRemaining();
            return _httpResponseMessage.ReturnOk(count);
        }
        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get(int branchId)
        {
            try
            {
                int generatedforHQ = _commissionPay.PaymentGeneratedforHQ(branchId);
                return _httpResponseMessage.ReturnOk(generatedforHQ);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get(int branchId, int commision)
        {
            try
            {
                int paymentRemaining = _commissionPay.PaymentRemaining(branchId);
                return _httpResponseMessage.ReturnOk(paymentRemaining);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("")]
        //[AllowAnonymous]
        public HttpResponseMessage Get(int branchId, string branchCode)
        {
            try
            {
                int completedtoHQ = _commissionPay.PaymentCompletedtoHQ(branchId);
                return _httpResponseMessage.ReturnOk(completedtoHQ);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateCourse([FromBody] JObject jsonData)
        {

            CommissionPay commissionPay = jsonData.ToObject<CommissionPay>();
            bool response = _commissionPay.CreateCommissionPay(commissionPay);
            return _httpResponseMessage.ReturnOk(response);


        }


        // PUT: api/Project/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateCourseBindPayment([FromBody] JObject jsonData)
        {
            CommissionPay commissionPay = jsonData.ToObject<CommissionPay>();
            var response = _commissionPay.UpdateCourseBindPayment(commissionPay);
            return _httpResponseMessage.ReturnOk(response);
        }

        //[HttpDelete]
        //[Route("")]
        //public HttpResponseMessage Delete(int courseId)
        //{
        //    var det = new Course() { Id = courseId };
        //    var response = _courseManager.DeleteCourse(det);
        //    return _httpResponseMessage.ReturnOk(response);
        //}
    }


}
