
using Marten;
using Microsoft.AspNetCore.Mvc;
using References.Api.External;

namespace References.Api.Links;

public class LinkController(IDocumentSession session, IValidateLinksWithSecurity linkValidator) : ControllerBase
{

    // some code here that will get called when a GET /links is sent to this server.

    [HttpGet("/links")]
    public async Task<ActionResult> GetAllLinksAsync(CancellationToken token)
    {


        var response = await session.Query<LinkEntity>().ToListAsync();
        return Ok(response);
    }

    [HttpPost("/links")]
    public async Task<ActionResult> AddALinkAsync([FromBody] LinkCreateRequest request, CancellationToken token)
    {

        // do your validation, did they send the right thing.

        var validationResult = await linkValidator.ValidateLinkAsync(new LinkValidationRequest(request.Href));
        if (validationResult.Status == LinkStatus.Good)
        {
            // create an entity and save that to the database
            var entityToSave = new LinkEntity()
            {
                Id = Guid.NewGuid(),
                Href = request.Href,
                Description = request.Description,
            };
            session.Store(entityToSave);
            await session.SaveChangesAsync();
            // return them a "copy" of what they saved to the database.
            return Ok(entityToSave);
        }
        if(validationResult.Status == LinkStatus.Blocked)
        {
            return BadRequest("That link is blocked by IT Security"); // 400
        }
        if (validationResult.Status == LinkStatus.Pending)
        {
            var pendingEntity = new PendingLinkEntity
            {
                Id = Guid.NewGuid(),
                CheckedOn = DateTimeOffset.UtcNow,
                Description = request.Description,
                Href = request.Href,
                Status = validationResult.Status
            };

            session.Store(pendingEntity);
            await session.SaveChangesAsync();

            return Redirect("/pending-links/" + pendingEntity.Id);
        }
        return NoContent(); // better than throwing an exception for now.
    }

    [HttpGet("/pending-links/{id:guid}")]
    public async Task<ActionResult> GetLinkById(Guid id)
    {
        var item = await session.Query<PendingLinkEntity>().SingleOrDefaultAsync(p => p.Id == id);

        if(item is not null)
        {
            return Ok(item);
        } else
        {
            return NotFound();
        }


    }


}

/*{
    "href": "https://microsoft.com",
    "description": "Microsoft's Main Site"
}*/

public record LinkCreateRequest(string Href, string Description);

public record LinkEntity
{
    public Guid Id { get; set; }
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public record PendingLinkEntity
{
    public Guid Id { get; set; }
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CheckedOn { get; set; } 
    public LinkStatus Status { get; set; }
}