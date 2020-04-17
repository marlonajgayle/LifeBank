using LifeBank.Api;
using LifeBank.Infrastructure.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
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
            // Specify Configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Setup Test Server
            Server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        [Fact]
        public void ApplicationHealthCheck()
        {
            var response = Client.GetAsync("/health");

            var result = response.Result.Content.ReadAsStringAsync();
            var healthCheckResponse = JsonConvert.DeserializeObject<HealthCheckResponse>(result.Result);

            Assert.Equal("Healthy", healthCheckResponse.Status);
            Assert.NotNull(healthCheckResponse.Checks);
            Assert.All(healthCheckResponse.Checks, item => Assert.Contains("Healthy", item.Status));
            Assert.All(healthCheckResponse.Checks, item => Assert.Contains("LifeBank API", item.Component));
            Assert.All(healthCheckResponse.Checks, item => Assert.NotNull(item.Description));
        }
    }
}