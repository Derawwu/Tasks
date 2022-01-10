using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPractice.Drivers;
using SpecFlowPractice.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    class FilteringSteps
    {
        public WebDriverChrome driver { get; }
        public WebDriverFirefox driverFirefox { get; }

        public FilteringSteps(WebDriverChrome driver, WebDriverFirefox driverFirefox)
        {
            this.driver = driver;
            this.driverFirefox = driverFirefox;
        }

        [Given(@"User enters to search bar text '(.*)' and press button enter , click on dropdown with filtering option")]
        public void GivenUserEntersToSearchBarTextAndPressButtonEnterClickOnDropdownWithFilteringOption(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            IWebElement searchTabFirefox = driverFirefox.Driver.FindElement(By.Id("search_query_top"));

            searchTab.SendKeys(searchRequest);
            searchTab.SendKeys(Keys.Enter);

            IWebElement dropdown = driver.Driver.FindElement(By.Id("selectProductSort"));
            dropdown.Click();

            searchTabFirefox.SendKeys(searchRequest);
            searchTabFirefox.SendKeys(Keys.Enter);

            WebDriverWait driverWaitFirefox = new WebDriverWait(driverFirefox.Driver, TimeSpan.FromSeconds(10));
            driverWaitFirefox.Until(ExpectedConditions.ElementIsVisible(By.Id("selectProductSort")));

            IWebElement dropdownFirefox = driverFirefox.Driver.FindElement(By.Id("selectProductSort"));
            dropdownFirefox.Click();
        }

        [When(@"choosed option from high to low price")]
        public void WhenChoosedOption()
        {
            driver.Driver.FindElement(By.XPath("//option[@value='price:desc'] ")).Click();
            driverFirefox.Driver.FindElement(By.XPath("//option[@value='price:desc'] ")).Click();
        }

        [Then(@"appropriate layout of items should be displayed")]
        public void ThenAppropriateLayoutOfItemsShouldBeDisplayed()
        {
            Filtering filtering = new(driver);
            filtering.HigherPriceFirst();

            FilteringFirefox filteringFirefox = new(driverFirefox);
            filteringFirefox.HigherPriceFirst();
        }


    }
}
