using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using rg.service.Manager;
using iTextSharp.tool.xml;
using rg.service.Models;
using rg.service.Utility;
namespace rg.service.Controllers
{
    [RoutePrefix("api/DatabaseBackup")]
    public class DatabaseBackupController : ApiController
    {
       
        private readonly IHttpResponseMessage _httpResponseMessage;
        public DatabaseBackupController(IHttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
            

        }

        [Route("")]
        public void Get()
        {
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage GetDatabaseBackUpFile()
        {
            // string test = "Hello World";
            try
            {
                DatabaseBackUp db=new DatabaseBackUp();
                return _httpResponseMessage.ReturnOk(db);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
