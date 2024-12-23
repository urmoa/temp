using Microsoft.AspNetCore.Mvc;
using PullWebSymbols.Server.Service;

namespace PullWebSymbols.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController(IHttpRequestService httpRequestService) : ControllerBase
{
    [HttpGet(Name = "search")]
    public async Task<ActionResult<Dictionary<string, int>>> Get([FromQuery] string search)
    {
       var res = await httpRequestService.ExecuteSearch(search);
       return Ok(res);
    }
}
