using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Footer;
using PortfolioAutomationTest.Assertions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.FooterTest
{
    [TestFixture]
    public class BackToTopTest : TestBase
    {
        [Test]
        public async Task TestBackToTop()
        {
            try
            {
                Console.WriteLine("Starting Back-to-Top Test...");

                IStep flow = new CheckBackToTopStep(Repository);
                flow.Chain(new BackToTopAssertion(Repository));

                await flow.Execute();

                Console.WriteLine("Back-to-Top Test completed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Back-to-Top Test failed: {ex.Message}");
            }
        }
    }
}
