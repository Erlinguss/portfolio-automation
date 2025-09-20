using PortfolioAutomation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PortfolioAutomation.Steps.DownloadCV
{
    public class CheckDownloadCV : BaseStep
    {
        public CheckDownloadCV(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Clicking Download CV link...");

            // Click the CV download link
            await page.ClickAsync("a:has-text('Download CV')");
            await page.WaitForTimeoutAsync(1000);
        }
    }
}