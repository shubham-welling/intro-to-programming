
using Microsoft.AspNetCore.Mvc;

namespace References.Api.Links;

public class LinkController : ControllerBase
{
    // some code here that will get called when a GET /links is sent to this server.

    [HttpGet("/links")]
    public async Task<ActionResult> GetAllLinksAsync(CancellationToken token)
    {
        return Ok();
    }
}
