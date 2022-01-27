using Microsoft.Edge.SeleniumTools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowPractice.Variables;
using System;
using System.IO;


namespace SpecFlowPracticeReworked.Drivers
{
    public class WebDriverSettingsSingleton
    {
        
        private static ConfigSettings config;
        private static string configSettingsPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/config.json";

        private static WebDriverSettingsSingleton? instance;
        private WebDriver driver;
        private WebDriverSettingsSingleton()
        {
            driver = CreateWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private WebDriver CreateWebDriver()
        {
            config = new ConfigSettings();
            ConfigurationBuilder builder = new();
            builder.AddJsonFile(configSettingsPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

            if (config.BrowserType.ToLower() == "chrome")
            {
                return new ChromeDriver();
            }
            else if (config.BrowserType.ToLower() == "firefox")
            {
                return new FirefoxDriver();
            }
            else if (config.BrowserType.ToLower() == "edge")
            {
                return new EdgeDriver();
            } 
            else return new ChromeDriver();
        }
        public static WebDriver Initialize()
        {
            if (instance == null)
                instance = new WebDriverSettingsSingleton();
            return instance.driver;
        }
    }
}
