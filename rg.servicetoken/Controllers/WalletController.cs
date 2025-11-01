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
    [RoutePrefix("api/Wallet")]
    public class WalletController : ApiController
    {
        private readonly IWalletManager _walletManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public WalletController(IHttpResponseMessage httpResponseMessage, IWalletManager walletManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _walletManager = walletManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Branch> branch = _walletManager.GetAllWalletBranch();
            return _httpResponseMessage.ReturnOk(branch);
        }

        [Route("")]
        public HttpResponseMessage Get(int branchId)
        {
            try
            {
                System.Collections.Generic.List<Wallet> wallet = _walletManager.GetBranchWallet(branchId);
                return _httpResponseMessage.ReturnOk(wallet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("")]
        public HttpResponseMessage Get(int branchId, string paymentNote)
        {
            System.Collections.Generic.List<Wallet> wallethistory = _walletManager.GetBranchWalletHistoryDetails(branchId, paymentNote);
            return _httpResponseMessage.ReturnOk(wallethistory);
        }
        //[Route("")]
        ////[AllowAnonymous]
        //public HttpResponseMessage Get(int projectId)
        //{
        //    try
        //    {
        //        var det = new Project() { ProjectId = projectId };

        //        var resourceDetails = _projectManager.ProjectDetails(det);
        //        return _httpResponseMessage.ReturnOk(resourceDetails);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateWallet([FromBody] JObject jsonData)
        {
            try
            {
                Wallet wallet = jsonData.ToObject<Wallet>();
                bool response = _walletManager.CreateWallet(wallet);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        
        //// PUT: api/Project/5
        //[HttpPut]
        //[Route("update")]
        //public HttpResponseMessage UpdateWalle([FromBody] JObject jsonData)
        //{
        //    Branch branch = jsonData.ToObject<Branch>();
        //    var response = _branchManager.UpdateBranch(branch);
        //    return _httpResponseMessage.ReturnOk(response);
        //}

        //[HttpDelete]
        //[Route("")]
        //public HttpResponseMessage Delete(int branchId)
        //{
        //    var det = new Branch() { Id = branchId };
        //    var response = _branchManager.DeleteBranch(det);
        //    return _httpResponseMessage.ReturnOk(response);
        //}
    }


}
