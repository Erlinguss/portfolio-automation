using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Navigation
{
    public class CheckNavigationMenu : BaseStep
    {
        public CheckNavigationMenu(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            // Define navigation links and expected URL paths
            var navLinks = new (string linkText, string expectedPath)[]
            {
                ("Home", "/"),
                ("About", "/about"),
                ("Projects", "/projects"),
                ("Skills", "/skills") 
            };

            foreach (var (linkText, expectedPath) in navLinks)
            {
                Console.WriteLine($"Testing navigation: {linkText}");

                // Click by visible text (covers both <a> and <button>)
                await page.ClickAsync($"text={linkText}");

                // Wait for navigation or scroll effect
                await page.WaitForTimeoutAsync(1000);

                // Validate URL contains the expected path
                var currentUrl = page.Url;
                if (!currentUrl.Contains(expectedPath))
                {
                    throw new Exception(
                        $"Navigation to {linkText} failed. Expected URL to contain '{expectedPath}', but got '{currentUrl}'."
                    );
                }

                Console.WriteLine($"✅ {linkText} navigation works! ({currentUrl})");
            }
        }
    }
}
