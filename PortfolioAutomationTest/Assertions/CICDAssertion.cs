using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest
{
    public class CICDAssertion : BaseStep
    {
        public CICDAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting CI/CD Section...");

            var page = Repository.Get<IPage>();
            await page.WaitForLoadStateAsync();

            // Look for the CI/CD Dashboard header
            var cicdLocator = page.Locator("h1:has-text('CI/CD Dashboard')");
            await Expect(cicdLocator).ToBeVisibleAsync();

            Console.WriteLine("CI/CD section is visible.");
        }
    }
}
