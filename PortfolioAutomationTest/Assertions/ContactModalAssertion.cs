using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class ContactModalAssertion : BaseStep
    {
        public ContactModalAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Asserting Contact modal...");

            // Assert modal title
            await page.WaitForTimeoutAsync(500);
            var modalTitle = page.Locator("#contact-modal-title");
            await Expect(modalTitle).ToHaveTextAsync("Get in touch");

            // Assert fields are visible
            await Expect(page.Locator("input[placeholder='Your name']")).ToBeVisibleAsync();
            await Expect(page.Locator("input[placeholder='you@company.com']")).ToBeVisibleAsync();
            await Expect(page.Locator("textarea[placeholder*='Tell me']")).ToBeVisibleAsync();

            // Assert Send button
            await Expect(page.Locator("button:has-text('Send Message')")).ToBeVisibleAsync();

            Console.WriteLine("Contact modal fields are visible and correct.");
        }
    }
}
