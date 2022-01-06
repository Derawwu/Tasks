using SpecFlowPractice.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        public WebDriverDriver driver { get; }

        public Hooks1(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver.Driver.Manage().Window.Maximize();
            driver.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Driver.Quit();
        }
    }
}
