using LifeBank.Api;
using LifeBank.Application.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using Xunit;

namespace LifeBank.UnitTests.Application
{
    public class ApplicationHealthCheckTests
    {
        private readonly TestServer Server;
        private readonly HttpClient Client;

        public ApplicationHealthCheckTests()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        [Fact]
        public void ApplicationHealthCheck()
        {
            var response = Client.GetAsync("/health");

            var result =  response.Result.Content.ReadAsStringAsync();
            var healthCheckResponse = JsonConvert.DeserializeObject<HealthCheckResponse>(result.Result);

            Assert.Equal("Healthy", healthCheckResponse.Status);
        }
    }
}