using System;
using System.Collections.Generic;
using System.Linq;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.PredefinedReports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BC.ACCOUNTING.REPORT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuranceInvoicesReportController : Controller
    {
        [HttpPost("ReportDivideInvoices")]
        public IActionResult ReportDivideInvoices([FromBody] List<ReportDividedInvoiceToDeliveriesDataSource> dto, [FromQuery] string deliveryName)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(deliveryName))
                    return BadRequest(new { message = "Invalid input parameters." });
                string jsonData = JsonConvert.SerializeObject(dto);
                // ✅ Store DTO list in Session (serialized as JSON)
                HttpContext.Session.SetString("DtoData", JsonConvert.SerializeObject(dto));
                HttpContext.Session.SetString("DeliveryName", deliveryName);
                Console.WriteLine("✅ Stored in Session: " + jsonData);



                // ✅ Return a JSON response with the redirect URL instead of an HTML View
                var redirectUrl = Url.Action(nameof(ReportDivideInvoicesView), "IssuranceInvoicesReport");
                return Ok(new { message = "Data stored successfully", redirectUrl = redirectUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }




        [HttpGet("ReportDivideInvoicesView")]
        public IActionResult ReportDivideInvoicesView()
        {
            Console.WriteLine("📌 Checking session storage...");
            Console.WriteLine("📌 Session Data: " + HttpContext.Session.GetString("DtoData"));
            // ✅ Retrieve DTO List from Session
            List<ReportDividedInvoiceToDeliveriesDataSource> dto = new();

            var dtoJson = HttpContext.Session.GetString("DtoData");
            if (!string.IsNullOrEmpty(dtoJson))
            {
                dto = JsonConvert.DeserializeObject<List<ReportDividedInvoiceToDeliveriesDataSource>>(dtoJson);
            }
            else
            {
                return BadRequest("No data found for the report.");
            }

            string deliveryName = HttpContext.Session.GetString("DeliveryName") ?? "Unknown";

            // ✅ Ensure Data Exists Before Processing
            if (!dto.Any())
                return BadRequest("Report data is empty.");

            // ✅ Initialize Report with Data
            var report = new ReportDividedInvoiceToDeliveries();
            report.InitData(dto, deliveryName);

            return View("ReportDivideInvoices", report);
        }



    }
}