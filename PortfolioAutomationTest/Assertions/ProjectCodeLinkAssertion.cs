using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.Assertions
{
    public class ProjectCodeLinkAssertion : BaseStep
    {
        public ProjectCodeLinkAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Asserting Project Code link...");

            //just check the button href
            var codeButton = page.Locator("a:has-text('Code')").First;
            var href = await codeButton.GetAttributeAsync("href");

            if (string.IsNullOrEmpty(href) || !href.Contains("github.com"))
            {
                throw new Exception($"Expected href to contain GitHub, but got: {href}");
            }

            Console.WriteLine($"Project Code link points to GitHub: {href}");
        }
    }
}
