using BoDi;
using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowPractice.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public sealed class SearchSteps
    {
        private static IWebDriver driver { get; set; }
        private readonly IObjectContainer container;

        public SearchSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>("WebDriver");
        }

        
        private ProductPageObject searchResult = new();
        private BasePageObject basePage = new();

        [When(@"User enters to search bar text '(.*)' and click on search button")]
        public void WhenUserEntersToSearchBarTextAndClickOnSearchButton(string searchRequest)
        {
            basePage.SearchBar(driver,searchRequest);
        }

        [Then(@"Main title text is ""(.*)""")]
        public void ThenMainTitleTextIs(string expectedResult)
        {
            var actualResult = searchResult.PageMainTitleText(driver);
            actualResult.Trim('«', '»').ToUpper().Should().Be(expectedResult);
        }
    }
}
