
namespace References.Api.External;

public class FakeLinkValidator : IValidateLinksWithSecurity
{
    public Task<LinkValidationResponse> ValidateLinkAsync(LinkValidationRequest request)
    {
        if(request.Href.ToLower().Contains("geico") )
        {
            return Task.FromResult(new LinkValidationResponse(LinkStatus.Pending));
        } else
        {
            return Task.FromResult(new LinkValidationResponse(LinkStatus.Good));
        }
    }
}
