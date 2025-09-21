using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class BackToTopAssertion : BaseStep
    {
        public BackToTopAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Asserting Back-to-Top action...");

            // Wait until scroll position is near top (<= 50 px tolerance)
            await page.WaitForFunctionAsync("() => window.scrollY <= 50");

            // Assert final scroll position
            var scrollY = await page.EvaluateAsync<int>("() => window.scrollY");
            if (scrollY > 50)
            {
                throw new Exception($"Expected to scroll near top, but still at position: {scrollY}");
            }

            Console.WriteLine("Back-to-Top button works. Page scrolled to top.");
        }
    }
}
