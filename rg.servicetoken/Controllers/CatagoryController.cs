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
    [RoutePrefix("api/Catagory")]
    public class CatagoryController : ApiController
    {
        private readonly ICatagoryManager _catagoryManager;
        private readonly IHttpResponseMessage _httpResponseMessage;

        public CatagoryController(IHttpResponseMessage httpResponseMessage, ICatagoryManager catagoryManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _catagoryManager = catagoryManager;

        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.List<Catagory> catagory = _catagoryManager.GetAllCatagory();
            return _httpResponseMessage.ReturnOk(catagory);
        }


        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateCatagory([FromBody] JObject jsonData)
        {
            try
            {
                Catagory catagory = jsonData.ToObject<Catagory>();
                bool response = _catagoryManager.CreateCatagory(catagory);
                return _httpResponseMessage.ReturnOk(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        
        //// PUT: api/Project/5
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateCatagory([FromBody] JObject jsonData)
        {
            Catagory catagory = jsonData.ToObject<Catagory>();
            var response = _catagoryManager.UpdateCatagory(catagory);
            return _httpResponseMessage.ReturnOk(response);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int catagoryId)
        {
            var det = new Catagory() { Id = catagoryId };
            var response = _catagoryManager.DeleteCatagory(det);
            return _httpResponseMessage.ReturnOk(response);
        }
    }


}
