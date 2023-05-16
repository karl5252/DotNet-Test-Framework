using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SelfServicePortal.Specs.Config;
using SelfServicePortal.Specs.Drivers;
using SelfServicePortal.Specs.PageObjects;
using SelfServicePortal.Specs.Steps;
using TechTalk.SpecFlow;

namespace SelfServicePortal.Specs.Hooks
{
    public class DriverHook 
    {
        [Binding]
        public class Hooks
        {
            [BeforeScenario]
            public void BeforeScenario()
            {
                ScenarioContextHelper.SetScenarioContext(ScenarioContext.Current);
            }
        }



        /*
        private DriverFixture _driverFixture;
        private readonly IDriverFactory _driverFactory = new PlaywrightDriverFactory();


        [BeforeScenario] public void BeforeScenario() 
        {
            _driverFixture = new DriverFixture(_driverFactory);
            ScenarioContext.Current.Set(_driverFixture);
            
        }
        [AfterScenario] public void AfterScenario() 
        {
            _driverFixture.Dispose();
        }*/
    }
}
