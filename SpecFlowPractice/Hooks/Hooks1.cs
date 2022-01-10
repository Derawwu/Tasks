using SpecFlowPractice.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        public WebDriverChrome driver { get; }
        public WebDriverFirefox driverFirefox { get; }

        public Hooks1(WebDriverChrome driver, WebDriverFirefox driverFirefox)
        {
            this.driver = driver;
            this.driverFirefox = driverFirefox;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string url = "http://automationpractice.com/index.php";
            driver.Driver.Manage().Window.Maximize();
            driver.Driver.Navigate().GoToUrl(url);

            driverFirefox.Driver.Manage().Window.Maximize();
            driverFirefox.Driver.Navigate().GoToUrl(url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Driver.Quit();
            driverFirefox.Driver.Quit();
        }
    }
}
