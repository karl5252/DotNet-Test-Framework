using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SelfServicePortal.Specs.Steps
{
    public static class ScenarioContextHelper
    {
        private static ScenarioContext _scenarioContext;

        public static void SetScenarioContext(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public static ScenarioContext GetScenarioContext()
        {
            return _scenarioContext;
        }
    }
}
