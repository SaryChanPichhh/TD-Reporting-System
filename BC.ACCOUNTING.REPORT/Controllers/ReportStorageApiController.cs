namespace BC.ACCOUNTING.REPORT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportStorageApiController : ControllerBase
{
    private readonly string _reportDirectory = @"D:\.NetAPI\Reports\Accounting"; 

    public ReportStorageApiController()
    {
        if (!Directory.Exists(_reportDirectory))
            Directory.CreateDirectory(_reportDirectory);
    }

    // ✅ POST: Upload a report
    [HttpPost("upload")]
    public async Task<IActionResult> UploadReport(IFormFile file)
    {
        if (file == null || !file.FileName.EndsWith(".repx"))
            return BadRequest("Invalid file");

        var filePath = Path.Combine(_reportDirectory, Path.GetFileName(file.FileName));

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { message = "Report uploaded successfully", path = filePath });
    }

    // ✅ GET: Download a report
    [HttpGet("download/{reportName}")]
    public IActionResult DownloadReport(string reportName)
    {
        var filePath = Path.Combine(_reportDirectory, reportName + ".repx");

        if (!System.IO.File.Exists(filePath))
            return NotFound("Report not found");

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/xml", reportName + ".repx");
    }
}