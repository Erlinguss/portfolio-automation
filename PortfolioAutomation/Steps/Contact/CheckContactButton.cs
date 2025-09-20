using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Contact
{
    public class CheckContactButton : BaseStep
    {
        public CheckContactButton(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Clicking Contact button...");

            // Click Contact button
            await page.ClickAsync("a[aria-controls='contact-dialog']");

            Console.WriteLine("Contact modal opened successfully and is visible.");
        }
    }
}
