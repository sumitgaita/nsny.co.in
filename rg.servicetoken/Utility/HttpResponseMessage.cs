using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace rg.service.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHttpResponseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnBadRequest(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnBadRequest(Object result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnUnAuthorized(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnUnAuthorized(Object result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnNotFound(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnNotFound(Object result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnOk(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnOk(Object result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnInternalServerError(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnInternalServerError(Object result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnCreated(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnCreated(Object result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnGone(string result);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnGone(Object result);
    }

    /// <summary>
    /// 
    /// </summary>
    public class BasicHttpResponseMessage : IHttpResponseMessage
    {
        HttpResponseMessage IHttpResponseMessage.ReturnBadRequest(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnUnAuthorized(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnNotFound(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnOk(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public HttpResponseMessage ReturnOk(Object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter()
                {
                    SerializerSettings = new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                }, "application/json")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnInternalServerError(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public HttpResponseMessage ReturnInternalServerError(Object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter()
                {
                    SerializerSettings = new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                }, "application/json")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnCreated(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public HttpResponseMessage ReturnCreated(Object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnBadRequest(Object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnUnAuthorized(Object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnNotFound(Object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnGone(string result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Gone)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return response;
        }

        HttpResponseMessage IHttpResponseMessage.ReturnGone(object result)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Gone)
            {
                Content = new ObjectContent<Object>(result, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }
    }
}