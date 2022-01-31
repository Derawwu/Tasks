using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SpecFlowPractice.Variables;
using SpecFlowPracticeReworked.Drivers;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Hooks
{
    [Binding]
    public class Hook
    {
        public static IWebDriver WebDriver { get; set; } = WebDriverSettingsSingleton.Initialize();

        public IWebDriver Driver { get { return WebDriver; } }

        public Hook(IObjectContainer container)
        {
            this.container = container;

        }

        static ConfigSettings config;
        static string configSettingsPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/config.json";
        private readonly IObjectContainer container;

        public void driver() { }

        [BeforeTestRun]
        public static void BeforeTestRun() 
        {

        }

        [BeforeScenario]
        public void BeforeScenario()
        {           
            config = new ConfigSettings();
            ConfigurationBuilder builder = new();
            builder.AddJsonFile(configSettingsPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(config.BaseUrl);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            container.RegisterInstanceAs(WebDriver,"WebDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
