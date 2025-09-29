using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Navigation
{
    public class CheckCICDNavigation : BaseStep
    {
        public CheckCICDNavigation(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Testing CI/CD navigation...");

            // Click the CI/CD link in the nav
            await page.ClickAsync("text=CI/CD");
            await page.WaitForTimeoutAsync(1000);

            // Check if the CI/CD Dashboard title is visible
            var cicdVisible = await page.IsVisibleAsync("text=CI/CD Dashboard");

            if (!cicdVisible)
            {
                throw new Exception("Navigation to CI/CD failed. CI/CD Dashboard not visible.");
            }

            Console.WriteLine("CI/CD navigation works! Dashboard is visible.");
        }
    }
}
