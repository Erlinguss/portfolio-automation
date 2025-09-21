using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class CopyEmailAssertion : BaseStep
    {
        public CopyEmailAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            // Verify the toast message appears
            var toast = page.Locator("text=Copied to clipboard!");
            await Expect(toast).ToBeVisibleAsync();

            Console.WriteLine("Copy Email button works and toast message is visible.");
        }
    }
}
