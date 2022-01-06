using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    class FilteringSteps
    {
        public WebDriverDriver driver { get; }

        public FilteringSteps(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User enters to search bar text '(.*)' and press button enter , click on dropdown with filtering option")]
        public void GivenUserEntersToSearchBarTextAndPressButtonEnterClickOnDropdownWithFilteringOption(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys(searchRequest);
            searchTab.SendKeys(Keys.Enter);
            IWebElement dropdown = driver.Driver.FindElement(By.Id("selectProductSort"));
            dropdown.Click();
        }

        [When(@"choosed option from high to low price")]
        public void WhenChoosedOption()
        {
            driver.Driver.FindElement(By.XPath("//option[@value='price:desc'] ")).Click();
        }

        [Then(@"appropriate layout of items should be displayed")]
        public void ThenAppropriateLayoutOfItemsShouldBeDisplayed()
        {
            Filtering filtering = new(driver);
            filtering.HigherPriceFirst();
        }


    }
}
