using Microsoft.Playwright;

namespace SelfServicePortal.Specs.Drivers
{
    public class PlaywrightDriverFactory : IDriverFactory
    {
        private readonly Dictionary<string, Func<IBrowser>> _browserFactory = new Dictionary<string, Func<IBrowser>>
        {
            {"chromium", () =>Playwright.CreateAsync().GetAwaiter().GetResult().Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false}).GetAwaiter().GetResult() },
            {"firefox", () =>Playwright.CreateAsync().GetAwaiter().GetResult().Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false}).GetAwaiter().GetResult() },
            {"webkit", () =>Playwright.CreateAsync().GetAwaiter().GetResult().Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false}).GetAwaiter().GetResult() },
            {"", () =>Playwright.CreateAsync().GetAwaiter().GetResult().Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false}).GetAwaiter().GetResult() }
        };
        public IBrowser NewBrowser(string browserType)
        {
            if (!_browserFactory.ContainsKey(browserType))
                throw new Exception($"Unsupported browser type {browserType}");

            return _browserFactory[browserType].Invoke();

        }
    }
}
