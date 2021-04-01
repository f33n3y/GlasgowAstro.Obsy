using GlasgowAstro.Obsy.Services.Abstractions;
using System;
using Xunit;
using FluentAssertions;
using NSubstitute;

namespace GlasgowAstro.Obsy.Tests
{
    public class AsteroidServiceTests
    {
        private readonly IAsteroidService _sut;

        public AsteroidServiceTests()
        {
            _sut = Substitute.For<IAsteroidService>();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
