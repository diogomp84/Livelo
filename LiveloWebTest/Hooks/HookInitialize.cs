using AutoWebFramework.Base;
using TechTalk.SpecFlow;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace LiveloWebTest.Hooks
{

    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [AfterStep]
        public void AfterEachStep()
        {
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
        }


        [BeforeScenario]
        public void Initialize()
        {
            InitializeSettings();
        }

        [AfterScenario]
        public void TestStop()
        {
           _parallelConfig.Driver.Quit();
        }
    }
}
