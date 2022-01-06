using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SpecFlowPractice.Drivers
{
    public class WebDriverDriver : IDisposable
    {
        private Lazy<IWebDriver> driver;

        public WebDriverDriver()
        {
            driver = new Lazy<IWebDriver>(() => CreateWebDriver());
        }
        private WebDriver CreateWebDriver()
        {
            return new ChromeDriver()
            {

            };
        }

        public IWebDriver Driver
        {
            get
            {
                return driver.Value;
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
