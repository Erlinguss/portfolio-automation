using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class AboutAssertion : BaseStep
    {
        public AboutAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting About Section...");

            var page = Repository.Get<IPage>();
            await page.WaitForLoadStateAsync();

            var aboutLocator = page.Locator("h1:has-text('Erling Munguia')");
            await Expect(aboutLocator).ToBeVisibleAsync();

            Console.WriteLine("About section is visible.");
        }
    }
}
