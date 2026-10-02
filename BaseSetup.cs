using Microsoft.Playwright;
using NUnit.Framework;

namespace playwright_jenkins_demo
{
    public class BaseSetup
    {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false
                });

            Page = await Browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status
                == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotDirectory = Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "TestResults",
                    "Screenshots");

                Directory.CreateDirectory(screenshotDirectory);

                string testName = TestContext.CurrentContext.Test.Name;

                string screenshotPath = Path.Combine(
                    screenshotDirectory,
                    $"{testName}.png");

                await Page.ScreenshotAsync(new()
                {
                    Path = screenshotPath
                });

                TestContext.AddTestAttachment(
                    screenshotPath,
                    "Failure Screenshot");
            }

            await Page.CloseAsync();
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}