using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace ApiAiBlazorLab.Tests
{
    using ApiAiBlazorLab.Services;

    using Xunit;


    public class CatFactServiceTests

    {
        [Fact]
        public async Task GetRandomFact_ReturnsFact()

        {

            var json = "{\"fact\":\"Cats sleep 16 hours a day.\",\"length\":32}";

            var client = new HttpClient(new FakeHandler(json));


            var service = new CatFactService(client);


            var result = await service.GetRandomFactAsync();


            Assert.Equal("Cats sleep 16 hours a day.", result);

        }

        [Fact]
        public async Task MissingFactProperty_ReturnsFallback()
        {
            // Arrange
            var json = "{\"length\":32}";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act
            var result = await service.GetRandomFactAsync();

            // Assert
            Assert.Equal("No cat fact received.", result);
        }

        [Fact]
        public async Task NullJson_ReturnsFallback()
        {
            // Arrange
            var json = "{\"fact\":null}";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act
            var result = await service.GetRandomFactAsync();

            // Assert
            Assert.Equal("No cat fact received.", result);
        }

        [Fact]
        public async Task InvalidJson_ReturnsFallback()
        {
            // Arrange
            var json = "{invalid json}";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act
            var result = await service.GetRandomFactAsync();

            // Assert
            Assert.Equal("No cat fact received.", result);
        }
    }
}
