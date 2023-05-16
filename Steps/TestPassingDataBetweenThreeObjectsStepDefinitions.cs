using Autofac;
using Dependency_Injection;
using Microsoft.Playwright;
using SelfServicePortal.Specs.Drivers;
using SelfServicePortal.Specs.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SelfServicePortal.Specs.Steps
{
    [Binding]
    public class TestPassingDataBetweenThreeObjectsStepDefinitions
    {
        private readonly IBrowser _browser;
        private readonly SampleTestPageDragDrop _sampleTestPageDragAndDrop;

        public TestPassingDataBetweenThreeObjectsStepDefinitions()
        {
            var container = ContainerConfig.Configure();

            _browser = container.Resolve<IBrowser>();//browser;

            //_sampleTestPage = container.Resolve<SampleTestPage>();//projectsPage;
            _sampleTestPageDragAndDrop = container.Resolve<SampleTestPageDragDrop>();
        }

        [Then(@"the user clicks different tabs")]
        public async Task ThenTheUserClicksDifferentTabs()
        {
            await _sampleTestPageDragAndDrop.ClickTabsAsync();
        }

    }
}
