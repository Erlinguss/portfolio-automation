using PortfolioAutomation.Abstractions;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.Assertions
{
    public class DownloadCVAssertion : BaseStep
    {
        public DownloadCVAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Asserting Download CV link...");

            // Locate the Download CV link
            var downloadLink = page.Locator("a:has-text('Download CV')").First;

            // Get its href attribute
            var href = await downloadLink.GetAttributeAsync("href");

            if (string.IsNullOrEmpty(href) || !href.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"Expected Download CV link to point to a PDF, but got: {href}");
            }

            Console.WriteLine($"Download CV link correctly points to a PDF: {href}");
        }
    }
}
