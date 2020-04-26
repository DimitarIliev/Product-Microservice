using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace FlixOne.BookStore.ProductService.IntegrationTests.Services
{
    public class ProductTest
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;
        public ProductTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _client.BaseAddress = new Uri("http://localhost:57910");
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            //Act
            var response = await _client.GetAsync("/GetProduct");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            //Assert
            Assert.NotEmpty(responseString);
        }
    }
}
