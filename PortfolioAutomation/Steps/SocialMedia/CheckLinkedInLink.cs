using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Social
{
    public class CheckLinkedInLink : BaseStep
    {
        public CheckLinkedInLink(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Clicking LinkedIn header link...");

            // Use the first LinkedIn link (header)
            var linkedInHeader = page.Locator("a[aria-label='Open LinkedIn profile']").First;

            await linkedInHeader.ClickAsync();

            // Ensure navigation is complete
            await page.WaitForPopupAsync();

            Console.WriteLine($"LinkedIn header link opened successfully");

        }
    }
}
