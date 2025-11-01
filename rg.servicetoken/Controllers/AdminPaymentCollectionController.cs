using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.Net.Http;
using System.Web.Http;

namespace rg.service.Controllers
{
    //[Authorize]
    [RoutePrefix("api/AdminPaymentCollection")]
    public class AdminPaymentCollectionController : ApiController
    {
        private readonly ICommissionPayManager _commissionPay;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public AdminPaymentCollectionController(IHttpResponseMessage httpResponseMessage, ICommissionPayManager commissionPay)
        {
            _httpResponseMessage = httpResponseMessage;
            _commissionPay = commissionPay;
        }

        //[Route("")]
        //public HttpResponseMessage Get()
        //{
        //    System.Collections.Generic.List<PaymentStatus> paymentCompleted = _commissionPay.GetAdminPaymentGeneratedatBranch();
        //    return _httpResponseMessage.ReturnOk(paymentCompleted);
        //}
        [Route("")]
        public HttpResponseMessage Get(int branchId, string fromdate, string todate)
        {
            try
            {
                dynamic count = new System.Dynamic.ExpandoObject();
                count.BranchOfficeEarning = _commissionPay.GetBranchOfficeEarning(branchId, fromdate, todate);
                count.HqOfficeEarning = _commissionPay.GetHQOfficeEarning(branchId, fromdate, todate);
                count.TotalEarning = _commissionPay.GetTotalEarning(branchId, fromdate, todate);
                return _httpResponseMessage.ReturnOk(count);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Route("")]
        public HttpResponseMessage Get(int branchId, string fromdate, string todate, int studentId)
        {
            try
            {
                System.Collections.Generic.List<BranchPaymentCollection> resourceDetails = _commissionPay.GetViewEarningDetails(branchId, fromdate, todate);
                return _httpResponseMessage.ReturnOk(resourceDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[Route("")]
        //public HttpResponseMessage Get(int paymentId, bool isAdmin)
        //{
        //    try
        //    {
        //        bool paymentUpdate = _commissionPay.PaymentUpdate(paymentId);
        //        return _httpResponseMessage.ReturnOk(paymentUpdate);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //[Route("")]
        //public HttpResponseMessage Get(int paymentId, string admin)
        //{
        //    try
        //    {
        //        bool paymentUpdatestatus = _commissionPay.PaymentUpdatestatus(paymentId);
        //        return _httpResponseMessage.ReturnOk(paymentUpdatestatus);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //[Route("")]
        //public HttpResponseMessage Get(string admin)
        //{
        //    System.Collections.Generic.List<PaymentStatus> paymentCompleted = _commissionPay.GetAdminPaymentSendHQ();
        //    return _httpResponseMessage.ReturnOk(paymentCompleted);
        //}
        //[Route("")]
        //public HttpResponseMessage Get(int branchId)
        //{
        //    try
        //    {
        //        System.Collections.Generic.List<PaymentStatus> paymentCompleted = _commissionPay.GetPaymentGeneratedatBranch(branchId);
        //        return _httpResponseMessage.ReturnOk(paymentCompleted);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //[Route("")]
        //public HttpResponseMessage Get(int branchId, int branchCode)
        //{
        //    try
        //    {
        //        System.Collections.Generic.List<PaymentStatus> paymentSendtoHQ = _commissionPay.GetPaymentSendtoHQ(branchId);
        //        return _httpResponseMessage.ReturnOk(paymentSendtoHQ);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //[Route("")]
        //public HttpResponseMessage Get(int branchId, string dt)
        //{
        //    try
        //    {
        //        int count = _branchStudentBind.PaymenCount(branchId, dt);
        //        return _httpResponseMessage.ReturnOk(count);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //[HttpPost]
        //[Route("")]
        //public HttpResponseMessage PaymentCollection([FromBody] JObject jsonData)
        //{

        //    BranchPaymentCollection paymentCollection = jsonData.ToObject<BranchPaymentCollection>();
        //    bool response = _branchStudentBind.CreatePaymentollection(paymentCollection);
        //    return _httpResponseMessage.ReturnOk(response);


        //}


        ////// PUT: api/Project/5
        //[HttpPut]
        //[Route("update")]
        //public HttpResponseMessage PaymentLastUpdate([FromBody] JObject jsonData)
        //{
        //    BranchPaymentCollection paymentLastUpdate = jsonData.ToObject<BranchPaymentCollection>();
        //    bool response = _branchStudentBind.PaymentLastUpdate(paymentLastUpdate);
        //    return _httpResponseMessage.ReturnOk(response);
        //}

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
