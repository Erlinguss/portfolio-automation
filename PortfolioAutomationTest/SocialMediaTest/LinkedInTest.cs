using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Social;
using PortfolioAutomationTest.Assertions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.SocialTest
{
    [TestFixture]
    public class SocialLinksTest : TestBase
    {
        [Test]
        public async Task TestSocialLinks()
        {
            try
            {
                Console.WriteLine("Starting Social Links Test...");

                IStep flow = new CheckLinkedInLink(Repository);

                await flow.Execute();

                Console.WriteLine(" Social links test executed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Social links test failed: {ex.Message}");
            }
        }
    }
}
