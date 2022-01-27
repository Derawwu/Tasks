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
        static ConfigSettings config;
        static string configSettingsPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/config.json";

        

        public static IWebDriver webDriver { get; set; } = WebDriverSettingsSingleton.Initialize();

        public IWebDriver Driver { get { return webDriver; } }

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


            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(config.BaseUrl);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            container.RegisterInstanceAs(webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Close();
        }
    }
}
