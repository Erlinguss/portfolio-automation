using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest.Assertions
{
    public class ProjectsAssertion : BaseStep
    {
        public ProjectsAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting Projects Section...");

            var page = Repository.Get<IPage>();
            await page.WaitForLoadStateAsync();

            var projectsLocator = page.Locator("h1:has-text('Featured Projects')");
            await Expect(projectsLocator).ToBeVisibleAsync();

            Console.WriteLine("Projects section is visible.");
        }
    }
}
