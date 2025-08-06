using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.CORE.DTO.AR;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.INFRASTRUCTURE.Helper;
using BC.ACCOUNTING.REPORT.DataSources;
using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.IService.ReportToken;
using BC.ACCOUNTING.REPORT.Models;
using BC.ACCOUNTING.REPORT.PredefinedReports;
using BC.ACCOUNTING.REPORT.PredefinedReports.AR;
using BC.ACCOUNTING.REPORT.PredefinedReports.Inventory;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.CustomerOrder;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.Sale_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing;
using BC.ACCOUNTING.REPORT.PredefinedReports.Purchase_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Order;
using BC.ACCOUNTING.REPORT.Services;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.CodeParser;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BC.ACCOUNTING.REPORT.PredefinedReports.Sale_Listing;

namespace BC.ACCOUNTING.REPORT.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _reportDirectory;
        private readonly ReportExportService _reportExportService;
        private readonly ITokenValidatorService _tokenValidator;
        public ReportsController(IOptions<ReportSettings> options,IUnitOfWork unitOfWork, ReportExportService reportExportService, ITokenValidatorService tokenValidatorService)
        {
            _unitOfWork = unitOfWork;
            _reportExportService = reportExportService;
            _tokenValidator = tokenValidatorService;
            _reportDirectory = options.Value.Directory;
        }

        [HttpPost("DailySaleReport")]
        public IActionResult DailySaleReport([FromBody] InvoiceReportDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new DailySaleReport(dto, reportPath);

            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);
        }

        [HttpPost("DailySaleReceipt")]
        public IActionResult DailySaleReceipt([FromBody] InvoiceReportDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new DailySale80Report(dto, reportPath);

            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);
        }

        [HttpPost("AR")]
        public async Task<IActionResult> AR([FromBody] AgingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            // Await the asynchronous method to get the list
            var arList = await _unitOfWork.AccountRecievables.GetAgingReport(dto);

            var report = new XtraReport();
            report.LoadLayoutFromXml(reportPath);

            // Create ObjectDataSource and bind to arList
            var objectDataSource = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            objectDataSource.DataSource = arList;
            report.DataSource = objectDataSource;

            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);
        }

        [HttpPost("Inventory")]
        public IActionResult Inventory([FromBody] InventoryReportDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new InventoryReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report); 
            
        }

        [HttpPost("PurchaseOrder")]
        public IActionResult PurchaseOrder([FromBody] PurchaseOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new PurchaseOrderReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

       
        [HttpPost("POListing")]
        public IActionResult POListing([FromBody] POListingDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new POListing(dto,reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpGet("SaleReport")]
        public IActionResult SaleReport()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var data = new List<SaleDto>
            {
                new SaleDto { ProductCode = "P001", ProductName = "Pen", Quantity = 10, UnitPrice = 1.50m, SaleDate = new DateTime(2025, 6, 20) },
                new SaleDto { ProductCode = "P001", ProductName = "Pen", Quantity = 5, UnitPrice = 1.50m, SaleDate = new DateTime(2025, 6, 25) },
                new SaleDto { ProductCode = "P002", ProductName = "Notebook", Quantity = 3, UnitPrice = 3.20m, SaleDate = new DateTime(2025, 6, 21) },
                new SaleDto { ProductCode = "P003", ProductName = "Eraser", Quantity = 15, UnitPrice = 0.80m, SaleDate = new DateTime(2025, 6, 22) }
            };
            string startDate = "2025-06-20";
            string endDate = "2025-06-25";

            var report = new SaleReport(data, startDate,endDate);
           

            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }
        [HttpPost("SaleInvoice")]
        public IActionResult SaleInvoice([FromBody] SaleInvoiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new SaleInvoiceReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("ARDepreciation")]
        public IActionResult SaleInvoice([FromBody] ArDepreciationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ARDepreciationReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("ArPaid")]
        public IActionResult ArPaid([FromBody] ArPaidDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ARPaidReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("ArCustomer")]
        public IActionResult ArCustomer([FromBody] ArCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ArCustomerReceipt(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }
        [HttpPost("ArCustomerSummary")]
        public IActionResult ArCustomerSummary([FromBody] ArCustomerSummaryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ARCustomerSummaryReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("ArCustomerSumInv")]
        public IActionResult ArCustomerSumInv([FromBody] ArCustomerSumInvDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ArCustomerSumInvReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("ArCustomerInvoice")]
        public IActionResult ArCustomerInvoice([FromBody] ArCustomerInvoiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ArCustomerInvoiceReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("ArCustomerPaidReceipt")]
        public IActionResult ArCustomerPaidReceipt([FromBody] ArCustomerPaidDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ArCustomerPaidReceipt(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("dailyclosinginventory")]
        public IActionResult Dailyclosinginventory([FromBody] DailyClosingInventoryDto inventoryDto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, inventoryDto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new DailyClosingInventoryReport(inventoryDto,reportPath);
            if (inventoryDto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, inventoryDto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(inventoryDto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{inventoryDto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }


        [HttpPost("dailyclosing")]
        public IActionResult Dailyclosing([FromBody] DailyClosingsDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new DailyClosingReport(dto,reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("customerorder")]
        public IActionResult CustomerOrder([FromBody] InvoiceItemDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new CustomerOrderReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("saleinvoice-vn7")]
        public IActionResult SaleInvoiceVn7([FromBody] SaleInvoiceDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new VN7SaleInvoiceReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("pos/saleinvoice")]
        public IActionResult PosSaleInvoice([FromBody] POSSaleInvoiceDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new POSSaleInvoiceReport(dto, reportPath);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("pos/salelisting")]
        public IActionResult PosSaleListing([FromBody] POSSaleListingByInvoiceDto dto, [FromQuery] bool isShowed = false)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            XtraReport report = isShowed 
                    ? new SaleListingByInvoiceReport(dto, reportPath)
                    : new SaleListingByInvoiceNoProfitReport(dto,reportPath);
                
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("salelisting")]
        public async Task<IActionResult> SaleListingAsync([FromBody] SaleListingDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            //var model = new SaleListingDto
            //{
            //    Code1 = dto.Code1,
            //    Code2 = dto.Code2,
            //    DbCode = dto.DbCode,
            //    Date1 = dto.Date1,
            //    Date2 = dto.Date2,
            //    DetailRecType = dto.DetailRecType,
            //    HeaderRecType = dto.HeaderRecType,
            //    Item1 = dto.Item1,
            //    Item2 = dto.Item2,
            //    Loc1 = dto.Loc1,
            //    Loc2 = dto.Loc2,
            //    Prd1 = dto.Prd1,
            //    Prd2 = dto.Prd2,
            //    Ref1 = dto.Ref1,
            //    Ref2 = dto.Ref2,
            //    VoidStatus = dto.VoidStatus,
            //    AnalM3 = dto.AnalM3,
            //    ReportName = null,
            //};
            var execute = await _unitOfWork.SaleListingRepository.GetSaleListingsAsync(dto);

            var report = new SaleListingReport(execute, reportPath, dto);
            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);
                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

        [HttpPost("pos/salelistingmovement")]
        public IActionResult PosSaleListingMovement([FromBody] POSSaleListingMovementDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new SaleListingMovementReport(dto,reportPath);

            if (dto.ExportFormat.HasValue)
            {
                var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
                var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

                return File(
                    fileBytes,
                    contentType,
                    $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
                );
            }
            ViewBag.HideHeader = true;
            return View("Invoice", report);

        }

    }
}