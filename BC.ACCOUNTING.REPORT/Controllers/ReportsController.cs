using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.CORE.DTO.AR;
using BC.ACCOUNTING.CORE.DTO.SaleListing;
using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.DTO.POS;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using BC.ACCOUNTING.REPORT.Helper;
using BC.ACCOUNTING.REPORT.Helper.Enums;
using BC.ACCOUNTING.REPORT.ImageCache;
using BC.ACCOUNTING.REPORT.Models;
using BC.ACCOUNTING.REPORT.PredefinedReports;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.ClosingEntry;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.CreditNote;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Customer;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Inventory;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Inventory.Expired;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Items;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Purchase_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Purchase_Order.SCS;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Listing;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.MB_Seller.Sale_Order.NO;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.CustomerOrder;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.Inventory;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.Purchase_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.Sale_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.SaleListing;
using BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.Audit;
using BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.ClosingEntry;
using BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.Inventory;
using BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.Purchase_Order;
using BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleInvoice;
using BC.ACCOUNTING.REPORT.PredefinedReports.RESTAURANT.SaleListing;
using BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AP;
using BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.AR;
using BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.Sale_Listing.ByDate.BySeller.Detail.M01;
using BC.ACCOUNTING.REPORT.PredefinedReports.SharedReport.Sale_Listing.ByDate.Summary;
using BC.ACCOUNTING.REPORT.Services;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DailyClosingReport = BC.ACCOUNTING.REPORT.PredefinedReports.POS.ClosingEntry.DailyClosingReport;


namespace BC.ACCOUNTING.REPORT.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _reportDirectory;
        private readonly ReportExportService _reportExportService;
        private readonly IConfiguration _configuration;
        private const string POSImageRoute = "ImageRoute:POSImageRoute";
        private readonly Dictionary<string, string>? _imageRoutes;
        private readonly Dictionary<string, string>? reportPOSDirectories;
        private readonly IImageCache _imageCache;
        private readonly IHttpClientFactory _factory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReportsController(IOptions<ReportSettings> options,IUnitOfWork unitOfWork, ReportExportService reportExportService, IConfiguration configuration, IImageCache imageCache, IHttpClientFactory factory, IHttpContextAccessor httpContextAccessor)
        {
            
            _unitOfWork = unitOfWork;
            _reportExportService = reportExportService;
            _configuration = configuration;
            _imageCache = imageCache;
            _factory = factory;
            _httpContextAccessor = httpContextAccessor;
            _reportDirectory = options.Value.Directory;
            _imageRoutes =  _configuration
                .GetSection("ImageRoute").Get<Dictionary<string, string>>(); 
            reportPOSDirectories =  _configuration
                .GetSection("ReportDirectories:POS_PATH").Get<Dictionary<string, string>>();

            ReportHelper.ReportDirectory = _reportDirectory;
            ReportHelper.ImageUrl = _imageRoutes;
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

        [HttpPost("mb-arcustomerinvoicedetail")]
        public IActionResult ARCustomerInvoiceDetail([FromBody] ARCustomerInvoiceDetailDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new ARCustomerInvoiceDetailReport(dto, reportPath);

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
        
        
        [HttpPost("mb-ap")]
        public async Task<IActionResult> AP([FromBody] AgingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var arList = await _unitOfWork.AccountRecievables.GetAgingReport(dto);
            var report = new APReport(arList,reportPath,dto.CompanyName);
            
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
        [HttpPost("mb-customerlisting")]
        public async Task<IActionResult> MBCustomerListing([FromBody] MBCustomersDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
 
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new MBCustomerListingA4Report(dto, reportPath);
            
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

        [HttpPost("mb-nosaleinvoice")]
        public IActionResult NOSaleInvoice([FromBody] NOSaleInvoiceDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            // Build dto.Data and each group's Items as usual…
            var report = new NOSaleInvoiceA4Report(dto, reportPath);

            // Now the report gets a single row per (TransRef, ItemCode, ItemDescKH)
            // with Qty and SalePrice aggregated, fixing the duplicate rows in your screenshot.
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

        [HttpPost("mb-apcustomervoucher")]
        public async Task<IActionResult> APCustomerVoucher([FromBody] ArCustomerPaidDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new APCustomerVoucherReport(dto,reportPath);
            
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
        [HttpPost("mb-apcustomerreceipt")]
        public async Task<IActionResult> APCustomerReceipt([FromBody] ArCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");


            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new APCustomerReceiptReport(dto,reportPath);
            
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
            const string startDate = "2025-06-20";
            const string endDate = "2025-06-25";

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
            var imageUrl = Path.Combine(_imageRoutes[ImagesPath.MB_SELLER_ROUTE.GetEnumDescription()]);
            var  report = new SaleInvoiceReport(dto, reportPath, imageUrl);
            
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
            return View("Invoice",report);

        }

        [HttpPost("ARDepreciation")]
        public IActionResult ARDepreciation([FromBody] ArDepreciationDto dto)
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
        public IActionResult Dailyclosinginventory([FromBody] DailyClosingInventoryDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            
            var report = new DailyClosingInventoryReport(dto, reportPath);
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


        [HttpPost("dailyclosing")]
        public IActionResult Dailyclosing([FromBody] DailyClosingsDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
           
            var report = new DailyClosingReport(dto, reportPath);
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
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var  report = new CustomerOrderReport(dto, reportPath);
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

        

        #region Point Of Sale


        [HttpPost("pos/saleinvoice")]
        public IActionResult PosSaleInvoice([FromBody] POSSaleInvoiceDto dto)
        {
            //var user = _tokenValidator    .ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM,
                dto.ReportMode ?? ReportModes.NormalMode);
      
            
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
        [HttpPost("pos/salelistingsummerybydate")]
        public IActionResult SaleListingView([FromBody] POSSaleListingReportDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM
                );

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new POSSaleListingReport(dto, reportPath);

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
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM,
                dto.ReportMode ?? ReportModes.NormalMode);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new SaleListingByInvoiceReport(dto, reportPath);

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
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new SaleListingMovementReport(dto, reportPath);
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
        [HttpPost("pos/inventoryaudit")]
        public IActionResult POSIUInventoryAudit([FromBody] InventoryDto dto)
        {

            if(!string.IsNullOrEmpty(dto.ShopImage))
            {
                dto.ShopImage =
                    Path.Combine(_configuration.GetSection(POSImageRoute).Value!, dto.ShopImage);
            }
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new IUInventoryAuditA4Report(dto, reportPath);

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
        [HttpPost("pos/inventory-audit")]
        public IActionResult POSInventoryAudit([FromBody] InventoryDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new IUInventoryAuditA4Report(dto, reportPath);
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


        [HttpPost("pos/salelistingsummary")]
        public IActionResult SaleListingSummary([FromBody] POSSalelistingSummaryDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM,
                dto.ReportMode ?? ReportModes.NormalMode);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new POSSaleListingSummaryReport(dto, reportPath);
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
        [HttpPost("pos/purchaseorder")]
        public async Task<IActionResult> POSPurchaseOrder([FromBody] RESPurchaseOrderDto dto,CancellationToken _cancellationToken)
        {

            var map = await _imageCache.PrefetchAsync(_factory, dto.Items.Where(x=>!string.IsNullOrEmpty(x.ItemImage) && x.ItemImage.Contains("http")).Select(x=>x.ItemImage).ToList(), _cancellationToken);
            foreach (var r in dto.Items)
                if (map.TryGetValue(r.ItemImage??"", out var b)) r.ImageByte = b;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new POSPurchaseOrderInvoiceReport(dto, reportPath);
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

        [HttpPost("pos-inventoryoutofstock")]
        public async Task<IActionResult> POSInventoryOutOfStock([FromBody] POSItemDto dto,CancellationToken cancellationToken)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            var map = await _imageCache.PrefetchAsync(_factory, dto.Items.Where(x=>!string.IsNullOrEmpty(x.Image)&&x.Image.Contains("http")).Select(x => x.Image).ToList(), cancellationToken);
            foreach (var r in dto.Items)
                if (map.TryGetValue(r.Image??"", out var b)) r.ImageByte = b;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString()??Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new POSInventoryOutOfStockReport(dto, reportPath);
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
        #endregion


        #region MB Restaurant


        [HttpPost("res-bzsaleinvoice")]
        public IActionResult RESBZSaleInvoice([FromBody] RESBZSaleInvoiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new RESBZSaleInvoiceA5Report(dto, reportPath);
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




        [HttpPost("res/inventoryoutofstock")]
        public async Task<IActionResult> RESInventoryOutOfStock([FromBody] RESItemDto dto,CancellationToken cancellationToken)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            var map = await _imageCache.PrefetchAsync(_factory, dto.Items.Select(x => x.Image).ToList(), cancellationToken);
            foreach (var r in dto.Items)
                if (map.TryGetValue(r.Image??"", out var b)) r.ImageByte = b;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

                  var  report = new RESInventoryOutOfStockReport(dto, reportPath);

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
        [HttpPost("res/saleinvoice")]
        public IActionResult RestaurantSaleInvoice([FromBody] RESSaleInvoiceDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESSaleInvoice80Report(dto, reportPath);
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
        
        [HttpPost("res/salereceipt")]
        public IActionResult RESSaleReceipt([FromBody] RESSaleReceiptDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESSaleReceipt58Report(dto, reportPath);
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
        [HttpPost("res/salelisting")]
        public IActionResult RestaurantSaleListing([FromBody] RESSaleListingInvoiceDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESSaleListingInvoiceProfitReport(dto, reportPath);
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

        [HttpPost("res/saleaudit")]
        public IActionResult CheckingInventory([FromBody] RESSaleInventoryDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESSaleAuditWithProfitA4Report(dto, reportPath);
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
        [HttpPost("res-purchaseorder")]
        public IActionResult RestaurantPurchaseOrder([FromBody] RESPurchaseOrderDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESPurchaseOrderReport(dto, reportPath);
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

        [HttpPost("res/dailyclosinginventory")]
        public IActionResult RestaurantSaleInvoice([FromBody] DailyClosingInventoryDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESDailyClosingInventory80Report(dto, reportPath);
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

        [HttpPost("res/salelistingsummary")]
        public IActionResult RestaurantSaleListingSummary([FromBody] RESSaleListingSummaryDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESSaleListingSummaryReport(dto, reportPath);
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
        
        [HttpPost("res/salelistingmovement")]
        public IActionResult RestaurantSaleListingMovement([FromBody] RESSaleListingMovementDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new RESSaleListingMovementReport(dto, reportPath);
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
        #endregion
        //[HttpPost("res/purchaseorder")]
        //public IActionResult RestaurantPurchaseOrder([FromBody] RESPurchaseOrderDto dto)
        //{
        //    //var user = _tokenValidator.ValidateJwtFromCookie(Request);
        //    //if (user == null)
        //    //    return Unauthorized();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

        //    if (!System.IO.File.Exists(reportPath))
        //        return NotFound("Report file not found.");

        //    var report = new POSPurchaseOrderByInvoiceReport(dto, reportPath);
        //    if (dto.ExportFormat.HasValue)
        //    {
        //        var fileBytes = _reportExportService.ExportReportToBytes(report, dto.ExportFormat.Value);
        //        var (contentType, extension) = _reportExportService.GetExportMetadata(dto.ExportFormat.Value);

        //        return File(
        //            fileBytes,
        //            contentType,
        //            $"{dto.ReportName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}"
        //        );
        //    }
        //    ViewBag.HideHeader = true;
        //    return View("Invoice", report);

        //}
        // ======================

        [HttpPost("salelisting")]
        public async Task<IActionResult> SaleListingAsync([FromBody] SaleListingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var execute = await _unitOfWork.SaleListingRepository.GetSaleListingsAsync(dto);
            var report = new SaleListingSummaryDailyReport(execute, reportPath, dto);
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

        [HttpPost("mo-salelisting")]
        public async Task<IActionResult> SaleListingForMOAsync([FromBody] SaleListingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var execute = await _unitOfWork.SaleListingRepository.GetSaleListingForMOAsync(dto);
            var report = new M01SaleListingDetailBySellerReport(execute, reportPath, dto);
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



        #region MB Seller


        [HttpPost("mb-itemsinfo")]
        public IActionResult ItemsInfo([FromBody] ItemInfoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new ItemInfoReport(dto,reportPath);
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


        [HttpPost("mb-saleinvoicesummary")]
        public IActionResult MBSaleInvoiceSummary([FromBody] MBSaleInvoiceSummaryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new MBSaleInvoiceSummaryReport(dto, reportPath);
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

        [HttpPost("mb-creditnote")]
        public IActionResult MBCreditNote([FromBody] CreditNoteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new CreditNoteReport(dto, reportPath);
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


        [HttpPost("mb-closinginventory")]
        public IActionResult MBClosingInventory([FromBody] ClosingInventoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new MBClosingInventoryA4Report(dto,reportPath);
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
        [HttpPost("mb-inventoryexpired")]
        public IActionResult MBInventoryExpired([FromBody] InventoryExpiredDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new InventoryExpiredReport(dto, reportPath);
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
        [HttpPost("mb-salelistingcustomer")]
        public IActionResult MBSaleListingCustomer([FromBody] MBSaleListingCustomereDto dto)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new MBSaleListingCustomerByInvoiceReport(dto, reportPath);
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


        [HttpPost("mb-salelistingsummary")]
        public IActionResult MBSaleListingSummary([FromBody] MBSaleListingSummaryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new MBSaleListingSummaryReport(dto, reportPath);
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
        [HttpPost("mb-incomeandexpense")]
        public IActionResult MBIncomeAndExpense([FromBody] IncomeExpenseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new MBIncomeAndExpenseA4Report(dto, reportPath);
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


        [HttpPost("mb-purchaseorder")]
        public async Task<IActionResult> MBPurchaseOrder([FromBody] RESPurchaseOrderDto dto,CancellationToken _cancellationToken)
        {
            //var user = _tokenValidator.ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();
            var map = await _imageCache.PrefetchAsync(_factory, dto.Items.Where(x => !string.IsNullOrEmpty(x.ItemImage) && x.ItemImage.Contains("http")).Select(x => x.ItemImage).ToList(), _cancellationToken);
            foreach (var r in dto.Items)
                if (map.TryGetValue(r.ItemImage??"", out var b)) r.ImageByte = b;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new PurchaseOrderInvoiceReport(dto, reportPath);
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
        #endregion
    }
}