using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Contact
{
    public class ClickContactFormSubmit : BaseStep
    {
        public ClickContactFormSubmit(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            Console.WriteLine("Clicking Contact form submit button...");

            // Locate submit button
            var submitButton = page.Locator("button[type='submit']");

            // Send emails
            await submitButton.ClickAsync();

            Console.WriteLine("Clicked Submit email).");
        }
    }
}
