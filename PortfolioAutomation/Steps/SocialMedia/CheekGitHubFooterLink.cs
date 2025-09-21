using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.SocialMedia
{
    public class CheckGitHubFooterLink : BaseStep
    {
        public CheckGitHubFooterLink(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Clicking GitHub footer link...");

            // Locate the GitHub link inside the footer
            var githubFooter = page.Locator("footer a[aria-label='Open GitHub profile']").First;

            // Scroll to Footer
            await githubFooter.ScrollIntoViewIfNeededAsync();

            // Click and wait for navigation
            await githubFooter.ClickAsync();

            // Ensure navigation is complete
            await page.WaitForPopupAsync();

            Console.WriteLine($"GitHub footer link opened successfully");
        }
    }
}
