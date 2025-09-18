using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class HomeAssertion : BaseStep
    {
        public HomeAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting Home Section...");

            var page = Repository.Get<IPage>();
            await page.WaitForLoadStateAsync();

            var homeLocator = page.Locator("h1:has-text('I’m Erling Munguia')");
            await Expect(homeLocator).ToBeVisibleAsync();

            Console.WriteLine("Home section is visible.");
        }
    }
}
