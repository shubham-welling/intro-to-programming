
using Alba;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using References.Api.External;
using References.Api.Links;

namespace References.Tests.Links;
public class AddingAPendingLink
{
    [Fact]
    public async Task AddingAPendingLinkReturnsProper()
    {
        var linkToAdd = new LinkCreateRequest("https://wwww.somesite.com", "Source Control Hub");
        var dummyLinkValidator = Substitute.For<IValidateLinksWithSecurity>();
        dummyLinkValidator
            .ValidateLinkAsync(Arg.Any<LinkValidationRequest>())
            .Returns(Task.FromResult(new LinkValidationResponse(LinkStatus.Pending)));
        var host = await AlbaHost.For<Program>(config =>
        {
            config.ConfigureTestServices(services =>
            {
                services.AddScoped(_ => dummyLinkValidator);
            });
        });

        var response = await host.Scenario(api =>
        {
            api.Post.Json(linkToAdd).ToUrl("/links");
            api.StatusCodeShouldBe(302);
        });

        Assert.NotNull(response);

        // follow the location header to see if it is actually there.

        var location = response.Context.Response.Headers.Location.Single();

        Assert.NotNull(location);


       var getResponse =  await host.Scenario(api =>
        {
            api.Get.Url(location); // /pending-links/839839893893
            api.StatusCodeShouldBeOk();
        });

        Assert.NotNull(getResponse);

        var getResponseBody = getResponse.ReadAsJson<PendingLinkEntity>();
        Assert.NotNull(getResponseBody);
      
        // etc. etc.
        Assert.Equal(LinkStatus.Pending, getResponseBody.Status);

    }
}
