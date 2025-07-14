namespace References.Api.External;

public interface IValidateLinksWithSecurity
{
    Task<LinkValidationResponse> ValidateLinkAsync(LinkValidationRequest request);
}

public record LinkValidationRequest(string Href);

public enum LinkStatus { Good, Blocked, Pending };
public record LinkValidationResponse(LinkStatus Status);
