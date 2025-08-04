using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BC.ACCOUNTING.REPORT.IService.ReportToken
{
    public interface ITokenValidatorService
    {
        ClaimsPrincipal ValidateJwtFromCookie(HttpRequest request);

    }
}
