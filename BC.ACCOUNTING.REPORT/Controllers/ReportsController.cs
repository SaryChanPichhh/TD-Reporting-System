
using BC.ACCOUNTING.REPORT.PredefinedReports.POS.PO;

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
        private readonly IHttpClientFactory _factory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        public ReportsController(IOptions<ReportSettings> options,IUnitOfWork unitOfWork, ReportExportService reportExportService, IConfiguration configuration,IHttpClientFactory factory, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            
            _unitOfWork = unitOfWork;
            _reportExportService = reportExportService;
            _configuration = configuration;
            _factory = factory;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");
            var jsonPath = Path.Combine(_env.WebRootPath,"jsonFiles","mikes_burger.json");
            var jsonString = System.IO.File.ReadAllText(path: jsonPath);
            List<NoAddressInfoModel>? data = new();
            try
            {
                var token = JToken.Parse(jsonString);
                
                if (token.Type == JTokenType.Array)
                {
                    data = token.ToObject<List<NoAddressInfoModel>>();
                }
                else if (token.Type == JTokenType.Object && token["Branches"] != null)
                {
                    data = token["Branches"]?.ToObject<List<NoAddressInfoModel>>();
                }
                else
                {
                    data = [];
                }
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (data != null) dto.Info = data.FirstOrDefault(x => x.BranchId == dto.DbCode);
            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");

            var report = new NOSaleInvoiceA4Report(dto, reportPath);
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

        [HttpPost("mb-apsupplierinvoicedetail")]
        public IActionResult APSupplierInvoiceDetail([FromBody] APSupplierInvoiceDetailDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");

            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new APSupplierInvoiceDetailReport(dto,reportPath);
            
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
        [HttpPost("mb-apsuppliersummary")]
        public IActionResult APSupplierSummaryReport([FromBody] APCustomerSummaryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");


            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new APSupplierSummaryReport(dto, reportPath);

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
        [HttpPost(template:"mb-appaid")]
        public IActionResult APPaidReport([FromBody] APPaidDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportPath = Path.Combine(_reportDirectory, dto.ReportName + ".repx");


            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new APPaidReport(dto, reportPath);

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
        [HttpPost("pos/pospolisting")]
        public IActionResult POSPOListing([FromBody] POSPOListingDto dto)
        {
            //var user = _tokenValidator    .ValidateJwtFromCookie(Request);
            //if (user == null)
            //    return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reportPath = ReportHelper.GetReportPath(_reportDirectory,
                reportPOSDirectories[dto.Language.ToString() ?? Languages.KM.ToString()], dto.ReportName, dto.Language ?? Languages.KM);


            if (!System.IO.File.Exists(reportPath))
                return NotFound("Report file not found.");
            var report = new POSPOListingReport(dto, reportPath);

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