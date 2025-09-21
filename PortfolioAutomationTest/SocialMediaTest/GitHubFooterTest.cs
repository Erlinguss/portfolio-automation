using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Social;
using PortfolioAutomation.Steps.SocialMedia;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.SocialTest
{
    [TestFixture]
    public class GitHubFooterTest : TestBase
    {
        [Test]
        public async Task TestGitHubFooterLink()
        {
            try
            {
                Console.WriteLine("Starting GitHub Footer Test...");

                IStep flow = new CheckGitHubFooterLink(Repository);
                await flow.Execute();

                Console.WriteLine("GitHub Footer link test passed.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"GitHub test failed: {ex.Message}");
            }
        }
    }
}
