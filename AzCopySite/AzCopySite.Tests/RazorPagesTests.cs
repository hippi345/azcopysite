using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AzCopySite.Tests;

public class RazorPagesTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public RazorPagesTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/", "Welcome to the AzCopy Site")]
    [InlineData("/About", "About")]
    [InlineData("/Privacy", "Privacy Policy")]
    [InlineData("/Contact", "Contact")]
    public async Task Page_returns_success_and_expected_content(string url, string expectedSnippet)
    {
        var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
        });

        using var response = await client.GetAsync(url);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var html = await response.Content.ReadAsStringAsync();
        Assert.Contains(expectedSnippet, html, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Error_page_returns_success()
    {
        var client = _factory.CreateClient();
        using var response = await client.GetAsync("/Error");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
