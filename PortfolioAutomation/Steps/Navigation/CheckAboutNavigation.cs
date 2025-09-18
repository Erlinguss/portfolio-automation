using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Navigation
{
    public class CheckAboutNavigation : BaseStep
    {
        public CheckAboutNavigation(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Testing About navigation...");

            await page.ClickAsync("text=About");
            await page.WaitForTimeoutAsync(1000);

            var currentUrl = page.Url;
            if (!currentUrl.Contains("/about"))
            {
                throw new Exception($"Navigation to About failed. Got URL: {currentUrl}");
            }

            Console.WriteLine($"About navigation works! ({currentUrl})");
        }
    }
}
