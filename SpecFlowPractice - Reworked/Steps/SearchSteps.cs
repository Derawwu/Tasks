using FluentAssertions;
using NUnit.Framework;
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
    public sealed class SearchSteps
    {
        public WebDriverSettings Driver { get; }
        private ProductPageObject SearchResult = new();
        private BasePageObject BasePage = new();

        public SearchSteps(WebDriverSettings driver)
        {
            this.Driver = driver;
        }

        [When(@"User enters to search bar text '(.*)' and click on search button")]
        public void WhenUserEntersToSearchBarTextAndClickOnSearchButton(string searchRequest)
        {
            BasePage.SearchBar(searchRequest);
        }

        [Then(@"Main title text is ""(.*)""")]
        public void ThenMainTitleTextIs(string expectedResult)
        {
            var actualResult = SearchResult.PageMainTitleText();
            actualResult.Trim('«', '»').ToUpper().Should().Be(expectedResult);
        }

    }
}
