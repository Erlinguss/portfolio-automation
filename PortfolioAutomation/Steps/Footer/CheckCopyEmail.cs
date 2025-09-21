using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Footer
{
    public class CheckCopyEmail : BaseStep
    {
        public CheckCopyEmail(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Clicking Copy Email button...");

            // Scroll to Footer
            var footerLocator = page.Locator("footer");
            await footerLocator.ScrollIntoViewIfNeededAsync();

            // Click the copy-to-clipboard button
            var copyButton = page.Locator("button[aria-label='Copy to clipboard']").First;
            await copyButton.ClickAsync();

            Console.WriteLine("Copy Email button clicked successfully");
        }
    }
}
