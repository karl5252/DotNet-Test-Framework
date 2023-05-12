using Microsoft.Playwright;

namespace SelfServicePortal.Specs.Drivers
{
    public interface IDriverFactory 
    {
        IBrowser NewBrowser(string browserType);
    }
}
