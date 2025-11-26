using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.REPORT.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order;
using DevExpress.XtraPrinting;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public class ReadJsonBody : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.HttpContext.Request;
            if (request.ContentType != null && request.ContentType.Contains("application/json"))
            {
                request.EnableBuffering(); request.Body.Position = 0;
                using var reader = new StreamReader(
                    request.Body,
                    encoding: Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: false,
                    bufferSize: 1024,
                    leaveOpen: true
                );
                var body = await reader.ReadToEndAsync();
                if (ReportHelper.IsAutoPrint)
                {
                    var reportInfo = ReportHelper.GetAutoPrintReportInstance(ReportHelper.ReportName);
                    var concreteClass = reportInfo.dto;
                    
                    if (reportInfo.dto != null)
                    {
                        var jsonConvert =(ReportDto) JsonConvert.DeserializeObject(body, concreteClass.GetType());

                        var report = reportInfo.reportFactory(jsonConvert);
                        var printTool = new PrintToolBase(report.PrintingSystem)
                        {
                            PrinterSettings = { PrinterName = ReportHelper.PrinterName }
                        };
                        Console.WriteLine(report);
                        Console.WriteLine("REPORT TYPE: " + report.GetType().Name);
                        Console.WriteLine("REPORT DATASOURCE: " + report.DataSource);
                        await report.CreateDocumentAsync();
                        Console.WriteLine("PAGE COUNT: " + report.Pages.Count);
                        printTool.Print();
                    }
                }
            }

            await next();
        }
    
    }
}
