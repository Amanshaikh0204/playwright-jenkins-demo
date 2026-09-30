using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using System.Text.RegularExpressions;

namespace playwright_jenkins_demo
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests 
    {
        [Test]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(page).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = page.Locator("text=Get Started");

            // Expect an attribute "to be strictly equal" to the value.
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            await Expect(page).ToHaveURLAsync(new Regex(".*intro"));
        }
    }
}
