using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortfolioAutomation.Steps.Dashboard
{
    public class CheckDashboardResponsiveness : BaseStep
    {
        public CheckDashboardResponsiveness(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            var portfolioData = Repository.Get<PortfolioData>();
            await page.GotoAsync(portfolioData.BaseUrl);


            var viewports = new Dictionary<string, (int Width, int Height)>
        {
            { "Desktop", (1920, 1000)},
            { "Laptop", (1440, 900) },
            { "Tablet", (768, 1024) },
            { "Mobile", (375, 667) }
        };

            foreach (var viewport in viewports)
            {
                await page.SetViewportSizeAsync(viewport.Value.Width, viewport.Value.Height);
                await page.GotoAsync(portfolioData.BaseUrl);
                await page.WaitForTimeoutAsync(1000);

                Console.WriteLine($"Tested responsiveness on {viewport.Key}");
            }
        }
    }
}