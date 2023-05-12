using Microsoft.Playwright;

namespace SelfServicePortal.Specs.Drivers
{

    public class DriverFixture : IDisposable
    {
        private readonly IDriverFactory _driverFactory;
        private readonly Dictionary<string, IBrowser> _browsers = new Dictionary<string, IBrowser>();
        
        public DriverFixture(IDriverFactory driverFactory) 
        {
            _driverFactory = driverFactory;
        }
        public IBrowser GetBrowser(string browserType) 
        {
            if (!_browsers.ContainsKey(browserType)) 
            {
                var browser = _driverFactory.NewBrowser(browserType);
                _browsers.Add(browserType, browser);
            }
            return _browsers[browserType];
        }
        public void Dispose()
        {
            foreach(var browser in _browsers.Values) 
            {
                browser.CloseAsync().GetAwaiter().GetResult();
            }
        }
    }
}
