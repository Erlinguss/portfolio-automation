using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Navigation
{
    public class CheckProjectsNavigation : BaseStep
    {
        public CheckProjectsNavigation(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Testing Projects navigation...");

            await page.ClickAsync("text=Projects");
          //  await page.WaitForTimeoutAsync(1000);
          await page.WaitForLoadStateAsync();

            var currentUrl = page.Url;
            if (!currentUrl.Contains("/projects"))
            {
                throw new Exception($"Navigation to Projects failed. Got URL: {currentUrl}");
            }

            Console.WriteLine($"Projects navigation works! ({currentUrl})");
        }
    }
}
