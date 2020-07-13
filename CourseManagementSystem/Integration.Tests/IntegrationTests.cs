using API;
using Microsoft.AspNetCore.Mvc.Testing;
using Persistence;
using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Integration.Tests
{
    public class IntegrationTest : IDisposable
    {
        protected readonly HttpClient TestClient;
        private readonly IServiceProvider _serviceProvider;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DataContext));
                        services.AddDbContext<DataContext>(opt =>
                        {
                            opt.UseInMemoryDatabase("TestDatabase");
                        });
                    });
                });

            _serviceProvider = appFactory.Services;
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DataContext>();
                Seed.SeedData(context);
            }
            TestClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
        }

    }  
}