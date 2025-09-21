using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Footer
{
    public class CheckBackToTopStep : BaseStep
    {
        public CheckBackToTopStep(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Clicking Back-to-Top button...");

            // Scroll down before clicking
            await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");

            // Click back-to-top button
            var backToTopButton = page.Locator("a[aria-label='Back to top']").First;
            await backToTopButton.ClickAsync();

            Console.WriteLine("Back-to-Top button clicked.");
        }
    }
}
