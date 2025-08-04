using System.Threading.Tasks;
using BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;
using BC.ACCOUNTING.CORE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BC.ACCOUNTING.REPORT.Controllers
{
    public class TDReportController : Controller
    {
        private readonly IReportPermissionService _reportPermissionService;

        public TDReportController(IReportPermissionService reportPermissionService)
        {
            _reportPermissionService = reportPermissionService;
        }
        public async Task<IActionResult> ReportList()
        {
            var model = await _reportPermissionService.GetAllReportAsync("POSConnection");
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TDReport model)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(ReportList));
            }
            return View(model);
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(string id)
        {
            
            return RedirectToAction("ReportList"); // redirect to the list after delete
        }

    }
}
