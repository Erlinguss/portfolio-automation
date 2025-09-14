using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;

namespace PortfolioAutomationTest.TestBase
{
    public class TestBase
    {
        protected IPage Page;
        protected IBrowser Browser;
        protected IRepository Repository;
        protected string EngineerEmail;
        protected string EngineerToken;
        protected string BaseUrl;

        [SetUp]
        public async Task Setup()
        {
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            BaseUrl = configuration["BaseUrl"] ?? throw new Exception("BaseUrl is not configured.");

            Console.WriteLine($"BaseUrl: {BaseUrl}");

            // Setup Playwright and Browser
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                BaseURL = BaseUrl
            });

            Page = await context.NewPageAsync();

            // Initialize Repository 
            Repository = new MemoryRepository();
            Repository.Add(Page);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
        }
    }
}
