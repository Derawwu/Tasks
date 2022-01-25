using FluentAssertions;
using SpecFlowPractice.Drivers;
using SpecFlowPractice.Pages;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    class CartSteps
    {
        public WebDriverSettings Driver { get; }
        private ProductPageObject SearchResult = new();
        private BasePageObject BasePage = new();
        private List<string> InfoAboutProductOnProductList = new();
        private List<string> InfoAboutProductOnCart = new();

        public CartSteps(WebDriverSettings driver)
        {
            this.Driver = driver;
        }

        [Given(@"User entered to search bar text '(.*)' and pressed button enter, after that filtering for expensive first had been chosen")]
        public void GivenUserEnteredToSearchBarTextAndPressedButtonEnterAfterThatFilteringForExpensiveFirstHadBeenChosen(string searchRequest)
        {
            BasePage.SearchBar(searchRequest);
            SearchResult.Sorting();
        }

        [When(@"User adds product to the cart and opens cart")]
        public void WhenUserAddsProductToTheCartAndOpensCart()
        {
            int productNumber = 1;
            InfoAboutProductOnProductList = SearchResult.AddProductToCart(productNumber);
            SearchResult.OpenCart();
        }

        [Then(@"Price of product in the cart must be same as price at the product list")]
        public void ThenPriceOfProductInTheCartMustBeSameAsPriceAtTheProductList()
        {
            InfoAboutProductOnCart = SearchResult.InfoAboutProductAlreadyAddedToTheCart();
            InfoAboutProductOnProductList.Should().BeEquivalentTo(InfoAboutProductOnCart);
        }
    }
}
