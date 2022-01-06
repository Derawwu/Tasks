using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using SpecFlowPractice.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    class CartSteps
    {
        public WebDriverDriver driver { get; }

        public CartSteps(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User enters to search bar text '(.*)' and press button enter, after that filter '(.*)' choosed")]
        public void GivenUserEntersToSearchBarTextAndPressButtonEnterAfterThatFilterChoosed(string searchRequest, string filter)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys(searchRequest);
            searchTab.SendKeys(Keys.Enter);

            IWebElement dropdown = driver.Driver.FindElement(By.Id("selectProductSort"));
            dropdown.Click();
            driver.Driver.FindElement(By.XPath($"//option[@value='{filter}'] ")).Click();
        }



        [When(@"User adds product to the cart and opens cart")]
        public void WhenUserAddsProductToTheCartAndOpensCart()
        {
            Cart cart = new(driver);
            cart.SavePriceAndAddToTheCart();
        }

        [Then(@"Price of product in the cart must be same as price at the product list")]
        public void ThenPriceOfProductInTheCartMustBeSameAsPriceAtTheProductList()
        {
            Cart cart = new(driver);
            cart.PriceAndNameCheckout();
        }

    }
}
