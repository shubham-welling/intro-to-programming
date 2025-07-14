using Alba;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using References.Api.External;
using References.Api.Links;

namespace References.Tests.Links;
public class AddingALink
{
    [Fact]
    public async Task CanAddALink()
    {
        // I am going to make an HTTP POST /Links to add a new link.
        // I am going to make sure that I get a success status code back,
        // And I'm going to check that what the POST returns has a body that includes the same URL and description I sent it.
        // THEN I'm going to do a GET request to /links and see if that new link I just added is in the list of links.

        var linkToAdd = new LinkCreateRequest("https://wwww.github.com", "Source Control Hub");
        var dummyLinkValidator = Substitute.For<IValidateLinksWithSecurity>();
        dummyLinkValidator
            .ValidateLinkAsync(Arg.Any<LinkValidationRequest>())
            .Returns(Task.FromResult(new LinkValidationResponse(LinkStatus.Good)));
        var host = await AlbaHost.For<Program>(config =>
        {
            config.ConfigureTestServices(services =>
            {
                services.AddScoped(_ => dummyLinkValidator);
            });
        });

        var postResponse = await host.Scenario(api =>
        {
            api.Post.Json(linkToAdd).ToUrl("/links");
            api.StatusCodeShouldBeOk();
        });

        Assert.NotNull(postResponse);

        var postEntityResponse = postResponse.ReadAsJson<LinkEntity>();

        Assert.NotNull(postEntityResponse);

        Assert.Equal(linkToAdd.Href, postEntityResponse.Href);
        Assert.Equal(linkToAdd.Description, postEntityResponse.Description);

        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url("/links");

        });

        var getResponseBody = getResponse.ReadAsJson<LinkEntity[]>();

        Assert.NotNull(getResponseBody);

        var linkIsCollection = getResponseBody.Single(a => a.Id == postEntityResponse.Id);

        Assert.Equal(linkIsCollection, postEntityResponse);
    }
}
