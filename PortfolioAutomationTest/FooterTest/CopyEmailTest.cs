using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Footer;
using PortfolioAutomationTest.Assertions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.FooterTest
{
    [TestFixture]
    public class CopyEmailTest : TestBase
    {
        [Test]
        public async Task TestCopyEmail()
        {
            try
            {
                Console.WriteLine("Starting Copy Email Test...");

                IStep flow = new CheckCopyEmail(Repository);
                flow.Chain(new CopyEmailAssertion(Repository));

                await flow.Execute();

                Console.WriteLine("Copy Email Test completed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Copy Email Test failed: {ex.Message}");
            }
        }
    }
}
