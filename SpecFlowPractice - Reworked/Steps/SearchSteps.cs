using FluentAssertions;
using SpecFlowPractice.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public sealed class SearchSteps
    {
        private ProductPageObject searchResult = new();
        private BasePageObject basePage = new();

        [When(@"User enters to search bar text '(.*)' and click on search button")]
        public void WhenUserEntersToSearchBarTextAndClickOnSearchButton(string searchRequest)
        {
            basePage.SearchBar(searchRequest);
        }

        [Then(@"Main title text is ""(.*)""")]
        public void ThenMainTitleTextIs(string expectedResult)
        {
            var actualResult = searchResult.PageMainTitleText();
            actualResult.Trim('«', '»').ToUpper().Should().Be(expectedResult);
        }
    }
}
