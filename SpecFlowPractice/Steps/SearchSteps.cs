using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public class SearchSteps
    {
        public WebDriverDriver driver { get; }

        public SearchSteps(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User enters to search bar text '(.*)' and press button enter")]
        public void GivenUserEntersToSearchBarText(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys(searchRequest);
            searchTab.SendKeys(Keys.Enter);
        }



        [Then(@"h1 text is '(.*)'")]
        public void ThenHTextIsAllSymbolsMustBeInTheUpperCase(string expectedResult)
        {
            IWebElement searchResult = driver.Driver.FindElement(By.CssSelector(".lighter"));
            Assert.That(expectedResult.Contains(searchResult.Text));
        }


    }
}
