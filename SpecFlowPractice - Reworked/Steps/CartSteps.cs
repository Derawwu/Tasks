using FluentAssertions;
using SpecFlowPractice.Pages;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SpecFlowPracticeReworked.Drivers;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public sealed class CartSteps
    {
        private ProductPageObject searchResult = new();
        private BasePageObject basePage = new();
        private List<string> infoAboutProductOnProductList = new();
        private List<string> infoAboutProductOnCart = new();

        [Given(@"the user entered to search bar text '(.*)' and pressed button enter, after that filtering for expensive first had been chosen")]
        public void GivenTheUserEnteredToSearchBarTextAndPressedButtonEnterAfterThatFilteringForExpensiveFirstHadBeenChosen(string searchRequest)
        {
            basePage.SearchBar(searchRequest);
            searchResult.Sorting();
        }

        [When(@"the user adds product to the cart")]
        public void WhenTheUserAddsProductToTheCart()
        {
            int productNumber = 1;
            infoAboutProductOnProductList = searchResult.AddProductToCart(productNumber);
        }

        [Then(@"user opens cart and the price of product in the cart must be same as price at the product list")]
        public void ThenUserOpensCartAndThePriceOfProductInTheCartMustBeSameAsPriceAtTheProductList()
        {
            searchResult.OpenCart();
            infoAboutProductOnCart = searchResult.InfoAboutProductAlreadyAddedToTheCart();
            infoAboutProductOnProductList.Should().BeEquivalentTo(infoAboutProductOnCart);
        }
    }
}
