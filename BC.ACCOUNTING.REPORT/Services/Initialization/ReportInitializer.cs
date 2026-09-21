using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BC.ACCOUNTING.APPLICATION.Interfaces.General;

namespace BC.ACCOUNTING.REPORT.Services.Initialization;

public class ReportInitializer(IServiceProvider serviceProvider) : IHostedService
{
    private const string ReportExtension = ".repx";
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var data =await unitOfWork.ReportManagementRepository.GetListReportAsync();
        
        // convert list to dictionary
        Dictionary<string, Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>> reports =
            new();
        foreach (var report in data)
        {
            if (report.ReportModes is null)continue;
            var subReport = new Dictionary<Languages, List<(ReportModes reportModes, string reportName)>>();
                foreach (var reportMode in report.ReportModes)
                {
                    var languages = (Languages)reportMode.ReportLanguage;
                    var mode = (ReportModes)reportMode.ReportMode;
                    if (!subReport.TryGetValue(languages, out var  modes))
                    {
                        modes = [];
                        subReport[languages] = modes;
                    }
                    modes.Add((mode,string.Concat(reportMode.ReportName,ReportExtension)));
                }
            reports.Add(report.MainReport, subReport);
        }
        //ReportHelper.Initialize(reports);
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}