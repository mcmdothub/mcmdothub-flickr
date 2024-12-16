using Flickr.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

public class FlickrPhotosServiceTests
{
    [Fact]
    public async Task SearchPhotosAsync_ReturnsResults_WhenApiReturnsValidData()
    {
        // Arrange

        // Mock HttpMessageHandler to simulate HttpClient behavior
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"photos\": {\"photo\": [{\"id\": \"12345\", \"title\": \"Test Photo\"}]}}")
            });

        var httpClient = new HttpClient(httpMessageHandlerMock.Object);

        // Mock IConfiguration to return an API key
        var configurationMock = new Mock<IConfiguration>();
        configurationMock.Setup(x => x["Flickr:ApiKey"]).Returns("test-api-key");

        // Mock ILogger
        var loggerMock = new Mock<ILogger<FlickrPhotosService>>();

        // Create the service instance
        var service = new FlickrPhotosService(httpClient, configurationMock.Object, loggerMock.Object);

        // Act
        var result = await service.SearchPhotosAsync("test-user");

        // Assert
        result.Should().NotBeNull("The result should not be null.");

        // Add explicit null checks
        result!.Photos.Should().NotBeNull("Photos property should not be null.");
        result.Photos!.Photo.Should().NotBeNullOrEmpty("Photo list should not be empty.");

        var firstPhoto = result.Photos.Photo![0];
        firstPhoto.Id.Should().Be("12345");
        firstPhoto.Title.Should().Be("Test Photo");
    }
}
