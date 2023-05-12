using Microsoft.Playwright;

namespace SelfServicePortal.Specs.Drivers
{
    public interface IPageFactory
    {
        Task<IPage> NewPageAsync();
    }
}