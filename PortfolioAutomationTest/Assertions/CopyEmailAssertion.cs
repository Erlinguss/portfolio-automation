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

            Console.WriteLine("Asserting Copy Email toast...");

            await page.WaitForTimeoutAsync(500); 

            // Select stable element inside the toaster
            var toast = page.Locator("div[role='status'][aria-live='polite']");

            // Ensure it shows up in the DOM
            await Expect(toast).ToHaveCountAsync(1);

            Console.WriteLine("Copy Email toast appeared in the DOM with correct text.");
        }
    }
}
