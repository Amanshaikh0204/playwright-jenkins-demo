using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using System.Text.RegularExpressions;

namespace playwright_jenkins_demo
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    [TestFixture]
    public class CommonTests : BaseSetup
    {
        [Test]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            await Page.GotoAsync("https://playwright.dev");

            await Expect(Page).ToHaveTitleAsync(
                new Regex("Playwright"));

            var getStarted = Page.Locator("text=Get Started");

            await Expect(getStarted).ToHaveAttributeAsync(
                "href",
                "/docs/intro");

            await getStarted.ClickAsync();

            await Expect(Page).ToHaveURLAsync(
                new Regex(".*intro"));
        }

        [Test]
        public async Task NewTest()
        {
            // do later
        }

        [Test]
        public async Task TestToFail()
        {
            await Page.GotoAsync("https://playwright.dev");

            await Expect(Page).ToHaveTitleAsync(
                new Regex("Playwright"));

            var getStarted = Page.Locator("text=Get Started");

            await Expect(getStarted).ToHaveAttributeAsync(
                "href",
                "/docs/intro");

            await getStarted.ClickAsync();

            await Expect(Page).ToHaveURLAsync(
                new Regex(".*intro123"));
        }
    }
}