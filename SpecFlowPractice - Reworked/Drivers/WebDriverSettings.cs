using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecFlowPractice.Variables;
using System;
using System.IO;

namespace SpecFlowPractice.Drivers
{
    public class WebDriverSettings : IDisposable
    {
        static ConfigSettings config;
        static string configSettingsPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/config.json";
        public static IWebDriver Driver { get; set; }

        public IWebDriver GetDriver()
        {   
            config = new ConfigSettings();
            ConfigurationBuilder builder = new();
            builder.AddJsonFile(configSettingsPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            if (config.BrowserType.ToLower() == "chrome")
            {
                Driver = new ChromeDriver();
            }
            else if (config.BrowserType.ToLower() == "firefox")
            {
                Driver = new FirefoxDriver();
            }
            else if (config.BrowserType.ToLower() == "edge")
            {
                Driver = new EdgeDriver();
            }
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return Driver;
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }

                disposed = true;
            }
        }
    }
}
