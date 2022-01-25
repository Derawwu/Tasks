using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using SpecFlowPractice.Variables;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Hooks
{
    [Binding]
    public sealed class Hook
    {
        static ConfigSettings config;
        static string configSettingsPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/config.json";

        public WebDriverSettings Driver = new WebDriverSettings();
        public IWebDriver WebDriver { get; set; }

        private readonly IObjectContainer container;

        public Hook(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            config = new ConfigSettings();
            ConfigurationBuilder builder = new();
            builder.AddJsonFile(configSettingsPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            WebDriver = this.Driver.GetDriver();

            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(config.BaseUrl);
            container.RegisterInstanceAs(WebDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}
