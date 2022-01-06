using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPractice.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public sealed class Deleting
    {
        public WebDriverDriver driver { get; }

        public Deleting(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User enters to search bar text ""(.*)"" and click on search button")]
        public void GivenUserEntersToSearchBarTextAndClickOnSearchButton(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys(searchRequest);
            driver.Driver.FindElement(By.Name("submit_search")).Click();
        }

        [Given(@"User clicks on button more for the first found product")]
        public void GivenUserClicksOnButtonMoreForTheFirstFoundProduct()
        {
            var productCard = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(productCard).Perform();
            driver.Driver.FindElement(By.CssSelector
                ("li>div>div>div.button-container>a.button.lnk_view.btn.btn-default>span")).Click();
        }

        [Given(@"user choose quantity=""(.*)"", size=""(.*)"", color = white")]
        public void GivenUserChooseQuantitySizeColorWhite(int amount, string size)
        {
            driver.Driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.Driver.FindElement(By.Id("quantity_wanted")).SendKeys(Convert.ToString(amount));

            driver.Driver.FindElement(By.Id("group_1")).Click();
            driver.Driver.FindElement(By.CssSelector($"#group_1>option[title={size}]")).Click();

            driver.Driver.FindElement(By.Id("color_8")).Click();
        }

        [Given(@"user click on the button ""(.*)""")]
        public void GivenUserClickOnTheButton(string button)
        {
            driver.Driver.FindElement(By.XPath($"//button[@type='submit']/span[text()='{button}']")).Click();
        }

        [Given(@"user click on button ""(.*)"" in the opened popup")]
        public void GivenUserClickOnButtonInTheOpenedPopup(string buttonContinue)
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            driver.Driver.FindElement(By.XPath($"//*[text()[contains(.,'{buttonContinue}')]]")).Click();
        }

        [Given(@"User clicks on the button more for first found product another one time")]
        public void GivenUserClicksOnTheButtonMoreForFirstFoundProductAnotherOneTime()
        {
            var productCard = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(productCard).Perform();
            driver.Driver.FindElement(By.CssSelector
                ("li>div>div>div.button-container>a.button.lnk_view.btn.btn-default>span")).Click();
        }

        [Given(@"user choose quantity=""(.*)"", size=""(.*)"", color = orange another one time")]
        public void GivenUserChooseQuantitySizeColorOrangeAnotherOneTime(int amount, string size)
        {
            driver.Driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.Driver.FindElement(By.Id("quantity_wanted")).SendKeys(Convert.ToString(amount));

            driver.Driver.FindElement(By.Id("group_1")).Click();
            driver.Driver.FindElement(By.CssSelector($"#group_1>option[title={size}]")).Click();

            driver.Driver.FindElement(By.Id("color_13")).Click();
        }

        [Given(@"user click on the button ""(.*)"" another one time")]
        public void GivenUserClickOnTheButtonAnotherOneTime(string button)
        {
            driver.Driver.FindElement(By.XPath($"//button[@type='submit']/span[text()='{button}']")).Click();
        }

        [Given(@"user click on the button ""(.*)"" in opened popup")]
        public void GivenUserClickOnTheButtonInOpenedPopup(string checkout)
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            driver.Driver.FindElement(By.CssSelector($"a[title='{checkout}']")).Click();
        }

        [When(@"user click on item's trashbin button")]
        public void WhenUserClickOnItemSTrashbinButton()
        {
            driver.Driver.FindElement(By.CssSelector("#product_5_25_0_0 a.cart_quantity_delete>i")).Click();
        }

        [Then(@"product removed from the cart")]
        public void ThenProductRemovedFromTheCart()
        {
            Thread.Sleep(1500);
            int cart = driver.Driver.FindElements(By.CssSelector("tbody>tr")).Count();
            Assert.That(cart,Is.EqualTo(1));
        }

    }
}
