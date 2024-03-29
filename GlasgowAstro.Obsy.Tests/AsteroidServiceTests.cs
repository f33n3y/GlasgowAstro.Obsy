using AutoFixture;
using FluentAssertions;
using GlasgowAstro.Obsy.Services;
using GlasgowAstro.Obsy.Services.Contracts;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using NSubstitute;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

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
        public async Task GetObservationsAsync_AsteroidNumberValid_ShouldReturnResponseWithObservations()
        {
            // Arrange
            const string asteroidNum = "134340";
            var apiResponse = _fixture.Create<AsteroidObservationDataResponse>();
            var request = new AsteroidObservationDataRequest { Number = asteroidNum };
            
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(apiResponse.Observations), Encoding.UTF8, "application/json")
            });
          
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler)
            {
                BaseAddress = new Uri("https://glasgowastro.co.uk")
            };

            _httpClientFactoryMock.CreateClient(Arg.Any<string>()).Returns(fakeHttpClient);
            _sut = new AsteroidService(_httpClientFactoryMock);

            // Act
            var result = await _sut.GetObservationsAsync(request);

            // Assert
            result.Should().BeOfType<AsteroidObservationDataResponse>()
                .Which.Observations.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetOrbitDataAsync__AsteroidNumberValid_ShouldReturnResponseWithMagnitude()
        {
            // Arrange
            const string asteroidNum = "134340";
            var apiResponse = _fixture.Create<AsteroidOrbitDataResponse>();
            var request = new AsteroidOrbitDataRequest { Number = asteroidNum };

            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(apiResponse.OrbitData), Encoding.UTF8, "application/json")
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
                .Which.OrbitData.Should().NotBeEmpty();
        }

    }
}
