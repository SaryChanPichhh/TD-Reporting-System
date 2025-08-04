using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BC.ACCOUNTING.API.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizeAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}
