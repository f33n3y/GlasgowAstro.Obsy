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

namespace GlasgowAstro.Obsy.Tests
{
    public class AsteroidServiceTests
    {
        private readonly IAsteroidService _sut;
        private readonly IHttpClientFactory _mockHttpClientFactory;
        private readonly IFixture _fixture = new Fixture();

        public AsteroidServiceTests()
        {
            _sut = Substitute.For<IAsteroidService>();
            _mockHttpClientFactory = Substitute.For<IHttpClientFactory>();
        }

        [Fact]
        public async Task GetOrbitDataAsync_ShouldReturnResponseWithMagnitude_WhenAsteroidNumberValid()
        {
            // Arrange
            //const string asteroidNum = "134340";
            //var apiReponse = _fixture.Create<AsteroidOrbitDataResponse>();
            //var request = new AsteroidOrbitDataRequest { Number = asteroidNum };

            
            // Act
            //var result = await _sut.GetOrbitDataAsync()

            // Assert
        }

    }
}
