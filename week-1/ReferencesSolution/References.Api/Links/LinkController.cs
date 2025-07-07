
using Microsoft.AspNetCore.Mvc;

namespace References.Api.Links
{
    public class LinkController : ControllerBase
    {
        [HttpGet("/links")]
        public async Task<ActionResult> GetAllLinksAsync(CancellationToken token)
        {
            return Ok();
        }
    }
}
