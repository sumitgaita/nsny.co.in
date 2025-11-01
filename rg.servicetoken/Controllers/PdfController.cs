using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using rg.service.Manager;
using rg.service.Models;
using rg.service.Utility;
using System;
using System.IO;
using System.Web.Http;

namespace rg.service.Controllers
{
    [Authorize]
    [RoutePrefix("api/Pdf")]

    public class PdfController : ApiController
    {
        private readonly IResourceManager _resourceManager;
        private readonly IHttpResponseMessage _httpResponseMessage;
        public PdfController(IHttpResponseMessage httpResponseMessage, IResourceManager resourceManager)
        {
            _httpResponseMessage = httpResponseMessage;
            _resourceManager = resourceManager;

        }

        [Route("")]
        public void Get()
        {
        }
        [HttpPost]
        [Route("")]
        public byte[] CreatePdf([FromBody] JObject jsonData)
        {

            try
            {
                int i = 0;
                int j = 0;
                Pdf res = jsonData.ToObject<Pdf>();
                string test = "<html>";

                test += " <body ><form>" +
                        "<table  border=\"1\" cellpadding='0' cellspacing='0' width='100%' style=\"margin-bottom: 0px;\">" +
                        "<tr style=\"height: 25px;\">";
                test += "<td align=\"center\" colspan=\"2\" style=\"text-align:center;font-weight:bold;font-size:10px;\">" + res.CreateDate + "</td>";
                test += "</tr>";
                test += "<tr style=\"height: 25px;\">";
                test += "<td width=\"50%\" style='text-align:center;font-size:10px;'>&nbsp;" + res.ProjectName + "</td>";
                test += "<td width=\"50%\" style='text-align:center;font-size:10px;'>Client:&nbsp;" + res.ClientName + "</td>";
                test += "</tr>";
                test += "</table>";
                test += "<table cellpadding='4' cellspacing='0'>";
                test += "<tr>";
                test += "<td>";
                test += "<table width='100%'>";
                test += "<tr>";
                test += "<td style='font-size:10px;'>Note:&nbsp;" + res.Note + "</td>";
                test += "</tr>";
                test += "<tr>";
                test += "<td style='font-size:10px;'>Weather:&nbsp;" + res.Weather + "</td>";
                test += "</tr>";
                test += "</table>";
                test += "</td>";
                test += "</tr>";
                test += "</table>";

                //loop start
                for (i = 0; i < res.PdfDetDetails.Count; i++)
                {
                    test += "<table cellpadding='4' cellspacing='0' width='100%'>";
                    test += "<tr>";
                    test +=
                        "<td style= \"font-size:10px;font-weight:bold\">Cost Code:<span>&nbsp;&nbsp;" + res.PdfDetDetails[i].costCodeDetails.costCodeName + "</span></td>";
                    test += "</tr>";
                    test += "<tr>";
                    test +=
                        " <td style=\"font-size:10px;\">Activities:<span>&nbsp;&nbsp;" + res.PdfDetDetails[i].costCodeDetails.costCodeActivity + "</span></td>";
                    test += "</tr>	";
                    test += "</table>";
                    test += "<table  border=\"1\" cellpadding='4' cellspacing='0' width='100%' style='margin:10px 0px 10px 0px;'>";
                    test += "<tr>";
                    test += "<th style=\"font-size:10px;\">Resource</th>";
                    test += "<th style=\"font-size:10px;\">Item Name</th>";
                    test += "<th style=\"font-size:10px;\">Supplier </th>";
                    test += "<th style=\"font-size:10px;\">Unit </th>";
                    test += "<th style=\"font-size:10px;\">Qty</th>";
                    test += "<th style=\"font-size:10px;\">Comment </th>";
                    test += "</tr>";
                    for (j = 0; j < res.PdfDetDetails[i].resourceList.Count; j++)
                    {
                        test += "<tr>";
                        test += "<td style=\"font-size:10px;\">" + res.PdfDetDetails[i].resourceList[j].resourceName + "</td>";
                        test += "<td style=\"font-size:10px;\">" + res.PdfDetDetails[i].resourceList[j].itemName + "</td>";
                        test += "<td style=\"font-size:10px;\">" + res.PdfDetDetails[i].resourceList[j].supplier + "</td>";
                        test += "<td style=\"font-size:10px;\">" + res.PdfDetDetails[i].resourceList[j].Cost + "</td>";
                        test += "<td style=\"font-size:10px;\">" + res.PdfDetDetails[i].resourceList[j].Qty + "</td>";
                        test += "<td style=\"font-size:10px;\">" + res.PdfDetDetails[i].resourceList[j].comments + "</td>";
                        test += "</tr>";
                    }
                    test += "</table>";
                }

                test += "</form> ";
                test += "</body>";
                test += "</html>";
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document doc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, ms))
                        {
                            doc.Open();
                            string finalHtml = test;
                            using (StringReader srHtml = new StringReader(finalHtml))
                            {
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                            }

                            doc.Close();
                        }
                    }
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
