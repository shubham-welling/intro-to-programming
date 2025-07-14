
using Alba;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using References.Api.External;
using References.Api.Links;

namespace References.Tests.Links;
public class AddingBlockedLink
{
    [Fact]
    public async Task AddingABlockedLinkGivesYouAFailure()
    {
        var linkToAdd = new LinkCreateRequest("https://wwww.somesite.com", "Source Control Hub");
        var dummyLinkValidator = Substitute.For<IValidateLinksWithSecurity>();
        dummyLinkValidator
            .ValidateLinkAsync(Arg.Any<LinkValidationRequest>())
            .Returns(Task.FromResult(new LinkValidationResponse(LinkStatus.Blocked)));
        var host = await AlbaHost.For<Program>(config =>
        {
            config.ConfigureTestServices(services =>
            {
                services.AddScoped(_ => dummyLinkValidator);
            });
        });

        await host.Scenario(api =>
        {
            api.Post.Json(linkToAdd).ToUrl("/links");
            api.StatusCodeShouldBe(400);
        });
    }
}
