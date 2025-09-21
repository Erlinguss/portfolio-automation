using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class ContactFormAssertion : BaseStep
    {
        public ContactFormAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Asserting contact form inputs...");

            // Name field
            await Expect(page.Locator("input[name='name']"))
                .ToHaveValueAsync(new Regex("Test User"));

            // Email field 
            await Expect(page.Locator("input[name='email']"))
                .ToHaveValueAsync(new Regex("@example\\.com"));

            // Message field 
            await Expect(page.Locator("textarea[name='message']"))
                .ToHaveValueAsync(new Regex("test message"));

            Console.WriteLine("Form inputs validated without submitting.");
        }
    }
}
