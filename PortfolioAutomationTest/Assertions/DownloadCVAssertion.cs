using PortfolioAutomation.Abstractions;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class DownloadCVAssertion : BaseStep
    {
        public DownloadCVAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting Download CV link...");

            var page = Repository.Get<IPage>();
            await page.WaitForLoadStateAsync();

            // Wait for navigation
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Assert PDF URL
            var url = page.Url;
            if (!url.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"CV link did not open a PDF. Found URL: {url}");
            }

            Console.WriteLine($"CV link opened successfully and points to PDF: {url}");
        }
    }
}
