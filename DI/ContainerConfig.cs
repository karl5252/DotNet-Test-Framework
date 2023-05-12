using Autofac;
using SelfServicePortal.Specs.Drivers;
using SelfServicePortal.Specs.PageObjects;
using Microsoft.Playwright;
using SelfServicePortal.Specs.Config;
using SelfServicePortal.Specs.Steps;

namespace Dependency_Injection
{


    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Register the driver factory
            builder.RegisterType<PlaywrightDriverFactory>().As<IDriverFactory>().SingleInstance();

            // Register the page objects
            builder.RegisterType<PageFactory>().As<IPageFactory>().SingleInstance();
            builder.RegisterType<GooglePage>().As<GooglePage>();
            builder.RegisterType<SampleTestPage>().As<SampleTestPage>();

            // Register StepDefinitions
            builder.RegisterType<TestPageFlowBetweenTwoObjects>();

            // Register the browser
            var browserType = AppConfig.BrowserType;
            builder.Register(ctx =>
            {
                var driverFactory = ctx.Resolve<IDriverFactory>();
                var browser = driverFactory.NewBrowser(browserType);
                return browser;
            }).As<IBrowser>().InstancePerLifetimeScope();

            return builder.Build();
        }

    }

}
