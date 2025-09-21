using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Contact
{
    public class FillContactForm : BaseStep
    {
        public FillContactForm(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Filling out contact form with timestamp...");

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            await page.FillAsync("input[name='name']", $"Test User {timestamp}");
            await page.FillAsync("input[name='email']", $"testuser+{DateTime.Now.Ticks}@example.com");
            await page.FillAsync("textarea[name='message']", $"This is a test message at {timestamp}.");

            Console.WriteLine($"Form filled successfully at {timestamp}.");
        }
    }
}
