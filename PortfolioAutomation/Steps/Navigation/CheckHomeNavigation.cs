using PortfolioAutomation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PortfolioAutomation.Steps.Navigation
{
    public class CheckHomeNavigation : BaseStep
    {
        public CheckHomeNavigation(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Testing Home navigation...");

            await page.ClickAsync("text=Home");
            await page.WaitForTimeoutAsync(1000);
         

            var currentUrl = page.Url;
            if (!currentUrl.EndsWith("/"))
            {
                throw new Exception($"Navigation to Home failed. Got URL: {currentUrl}");
            }

            Console.WriteLine($"Home navigation works! ({currentUrl})");
        }
    }
}
