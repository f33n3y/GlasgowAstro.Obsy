using GlasgowAstro.Obsy.Services.Abstractions;
using System;
using Xunit;
using FluentAssertions;
using NSubstitute;
using AutoFixture;
using System.Threading.Tasks;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Text;
using GlasgowAstro.Obsy.Services;

namespace GlasgowAstro.Obsy.Tests
{
    public class AsteroidServiceTests
    {
        private IAsteroidService _sut;
        private IFixture _fixture = new Fixture();
        private IHttpClientFactory _httpClientFactoryMock;

        public AsteroidServiceTests()
        {
            _httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
        }

        [Fact]
        public async Task GetOrbitDataAsync__AsteroidNumberValid_ShouldReturnResponseWithMagnitude()
        {
            // Arrange
            const string asteroidNum = "134340";
            var apiReponse = _fixture.Create<AsteroidOrbitDataResponse>();
            var request = new AsteroidOrbitDataRequest { Number = asteroidNum };

            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(apiReponse.OrbitData), Encoding.UTF8, "application/json")
            });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler)
            {
                BaseAddress = new Uri("https://glasgowastro.co.uk")
            };
            _httpClientFactoryMock.CreateClient(Arg.Any<string>()).Returns(fakeHttpClient);

            _sut = new AsteroidService(_httpClientFactoryMock);

            // Act
            var result = await _sut.GetOrbitDataAsync(request);

            // Assert
            result.Should().BeOfType<AsteroidOrbitDataResponse>()
                .Which.OrbitData.AbsoluteMagnitude.Should().NotBeNullOrWhiteSpace();
        }

    }
}
