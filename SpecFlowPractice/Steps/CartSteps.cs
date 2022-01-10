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
    class CartSteps
    {
        public WebDriverChrome driver { get; }
        public WebDriverFirefox driverFirefox { get; }

        public CartSteps(WebDriverChrome driver, WebDriverFirefox driverFirefox)
        {
            this.driver = driver;
            this.driverFirefox = driverFirefox;
        }



        [Given(@"User enters to search bar text '(.*)' and press button enter, after that filter '(.*)' choosed")]
        public void GivenUserEntersToSearchBarTextAndPressButtonEnterAfterThatFilterChoosed(string searchRequest, string filter)
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


            driver.Driver.FindElement(By.XPath($"//option[@value='{filter}'] ")).Click();
            driverFirefox.Driver.FindElement(By.XPath($"//option[@value='{filter}'] ")).Click();
        }



        [When(@"User adds product to the cart and opens cart")]
        public void WhenUserAddsProductToTheCartAndOpensCart()
        {
            Cart cart = new(driver);
            cart.SavePriceAndAddToTheCart();

            CartFirefox cartFirefox = new(driverFirefox);
            cartFirefox.SavePriceAndAddToTheCart();
        }

        [Then(@"Price of product in the cart must be same as price at the product list")]
        public void ThenPriceOfProductInTheCartMustBeSameAsPriceAtTheProductList()
        {
            Cart cart = new(driver);
            cart.PriceAndNameCheckout();

            CartFirefox cartFirefox = new(driverFirefox);
            cartFirefox.PriceAndNameCheckout();
        }

    }
}
