using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Projects
{
    public class CheckProjectCodeLink: BaseStep
    {
        public CheckProjectCodeLink(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Clicking Featured Project Code link...");

            // Click the first "Code" button found
            var codeButton = page.Locator("a:has-text('Code')").First;
            await codeButton.ClickAsync();

            Console.WriteLine("Project Code link clicked.");
        }
    }
}
