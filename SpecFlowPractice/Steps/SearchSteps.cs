using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPractice.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public class SearchSteps
    {
        public WebDriverChrome driver { get; }
        public WebDriverFirefox driverFirefox { get; }

        public SearchSteps(WebDriverChrome driver, WebDriverFirefox driverFirefox)
        {
            this.driver = driver;
            this.driverFirefox = driverFirefox;
        }

        [Given(@"User enters to search bar text '(.*)' and press button enter")]
        public void GivenUserEntersToSearchBarText(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            IWebElement searchTabFirefox = driverFirefox.Driver.FindElement(By.Id("search_query_top"));

            searchTab.SendKeys(searchRequest);
            searchTab.SendKeys(Keys.Enter);

            searchTabFirefox.SendKeys(searchRequest);
            searchTabFirefox.SendKeys(Keys.Enter);
        }



        [Then(@"h1 text is '(.*)'")]
        public void ThenHTextIsAllSymbolsMustBeInTheUpperCase(string expectedResult)
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".lighter")));

            WebDriverWait driverWaitFirefox = new WebDriverWait(driverFirefox.Driver, TimeSpan.FromSeconds(10));
            driverWaitFirefox.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".lighter")));

            IWebElement searchResult = driver.Driver.FindElement(By.CssSelector(".lighter"));
            IWebElement searchResultFirefox = driverFirefox.Driver.FindElement(By.CssSelector(".lighter"));

            Assert.That(expectedResult.Contains(searchResult.Text));
            Assert.That(expectedResult.Contains(searchResultFirefox.Text));
        }


    }
}
