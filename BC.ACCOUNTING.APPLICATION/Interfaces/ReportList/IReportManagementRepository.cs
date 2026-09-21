using BC.ACCOUNTING.CORE.DTO.Report;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.ReportList;

public interface IReportManagementRepository
{
    Task<List<ReportResponseDTO>> GetListReportAsync();
}