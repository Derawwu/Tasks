using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using FirefoxDriver driver = new FirefoxDriver("C:/Program Files/Mozilla Firefox/firefox.exe");

namespace SpecFlowPractice.Drivers
{
    public class WebDriverFirefox : IDisposable
    {
        private Lazy<IWebDriver> driverFirefox;

        public WebDriverFirefox()
        {
            driverFirefox = new Lazy<IWebDriver>(() => CreateWebDriver());
        }
        private WebDriver CreateWebDriver()
        {
            return new FirefoxDriver();
            {

            };
        }

        public IWebDriver Driver
        {
            get
            {
                return driverFirefox.Value;
            }
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
