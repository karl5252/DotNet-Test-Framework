using Microsoft.Playwright;

namespace SelfServicePortal.Specs.Drivers
{
    public class Driver : IDisposable
    {
        //driver pattern
        private readonly Task<IPage> _page;
        
        public Driver()
        {
            _page = InitializeBrowser();
        }
        public IPage Page => _page.Result;
        private IBrowser? _browser;

        public void Dispose()
        {
            _browser?.CloseAsync();
        }
        

        public async Task<IPage> InitializeBrowser()
        {
            var playwright = await Playwright.CreateAsync();
            //StorageStatePath = "Auth/auth.json"
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 20000,

            }) ;
            /*var context = await _browser.NewContextAsync(new()
            {
                StorageStatePath = "C:\\Users\\karol\\source\\repos\\PlaywrightTests\\Auth\\auth.json"
            });*/


            return await _browser.NewPageAsync();
        }
    }
}
