using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPractice.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPractice.Steps
{
    [Binding]
    public sealed class TwoToCart
    {
        private static string name1;
        private static string name2;
        private static string color1;
        private static string color2;
        private static string size1;
        private static string size2;
        private static string unitPrice1;
        private static string unitPrice2;
        private static string amount1;
        private static string amount2;
        private static double totalPrice1;
        private static double totalPrice2;

        public WebDriverDriver driver { get; }

        public TwoToCart(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User enters to search bar text ""(.*)"" and click on the search button")]
        public void GivenUserEntersToSearchBarTextAndClickOnTheSearchButton(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys(searchRequest);
            driver.Driver.FindElement(By.Name("submit_search")).Click();
        }



        [Given(@"User clicks on button more for first found product")]
        public void GivenUserClicksOnButtonMoreForFirstFoundProduct()
        {
            name1 = driver.Driver.FindElement(By.CssSelector("ul>:first-child>div>div>h5[itemprop]>:first-child")).Text;

            var productCard = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(productCard).Perform();
            driver.Driver.FindElement(By.CssSelector
                ("li>div>div>div.button-container>a.button.lnk_view.btn.btn-default>span")).Click();
        }

        [Given(@"user choose quantity=""(.*)"", size=""(.*)"", color=white")]
        public void GivenUserChooseQuantitySizeColorWhite(string amount, string size)
        {
            amount1 = amount;
            size1 = size;
            unitPrice1 = driver.Driver.FindElement(By.Id("our_price_display")).Text;
            double doubleAmount1 = Convert.ToDouble(amount);
            double doubleUnitPrice1 = Convert.ToDouble(driver.Driver.FindElement(By.Id("our_price_display")).Text.Trim('$'));
            totalPrice1 = doubleAmount1 * doubleUnitPrice1;

            driver.Driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.Driver.FindElement(By.Id("quantity_wanted")).SendKeys(Convert.ToString(amount));

            driver.Driver.FindElement(By.Id("group_1")).Click();
            driver.Driver.FindElement(By.CssSelector($"#group_1>option[title={size}]")).Click();

            color1 = driver.Driver.FindElement(By.Id("color_8")).GetAttribute("title");
            driver.Driver.FindElement(By.Id("color_8")).Click();
        }

        [Given(@"user click on button ""(.*)""")]
        public void GivenUserClickOnButton(string button)
        {
            driver.Driver.FindElement(By.XPath($"//button[@type='submit']/span[text()='{button}']")).Click();
        }

        [Given(@"user click on button ""(.*)"" in opened popup")]
        public void GivenUserClickOnButtonInOpenedPopup(string buttonContinue)
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            driver.Driver.FindElement(By.XPath($"//*[text()[contains(.,'{buttonContinue}')]]")).Click();
        }

        [Given(@"User enters to search bar text ""(.*)"" and click on search button another one time")]
        public void GivenUserEntersToSearchBarTextAndClickOnSearchButtonAnotherOneTime(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.Clear();
            searchTab.SendKeys(searchRequest);
            driver.Driver.FindElement(By.Name("submit_search")).Click();
        }

        [Given(@"User clicks on button more for first found product another one time")]
        public void GivenUserClicksOnButtonMoreForFirstFoundProductAnotherOneTime()
        {
            name2 = driver.Driver.FindElement(By.CssSelector("ul>:first-child>div>div>h5[itemprop]>:first-child")).Text;

            var productCard = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(productCard).Perform();
            driver.Driver.FindElement(By.CssSelector
                ("li>div>div>div.button-container>a.button.lnk_view.btn.btn-default>span")).Click();
        }

        [Given(@"user choose quantity=""(.*)"", size=""(.*)"", color=orange another one time")]
        public void GivenUserChooseQuantitySizeColorOrangeAnotherOneTime(string amount, string size)
        {
            amount2 = amount;
            size2 = size;
            unitPrice2 = driver.Driver.FindElement(By.Id("our_price_display")).Text;
            double doubleAmount2 = Convert.ToDouble(amount);
            double doubleUnitPrice2 = Convert.ToDouble(driver.Driver.FindElement(By.Id("our_price_display")).Text.Trim('$'));
            totalPrice2 = doubleAmount2 * doubleUnitPrice2;

            driver.Driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.Driver.FindElement(By.Id("quantity_wanted")).SendKeys(Convert.ToString(amount));

            driver.Driver.FindElement(By.Id("group_1")).Click();
            driver.Driver.FindElement(By.CssSelector($"#group_1>option[title={size}]")).Click();

            color2 = driver.Driver.FindElement(By.Id("color_13")).GetAttribute("title");
            driver.Driver.FindElement(By.Id("color_13")).Click();
        }

        [Given(@"user click on button ""(.*)"" another one time")]
        public void GivenUserClickOnButtonAnotherOneTime(string button)
        {
            driver.Driver.FindElement(By.XPath($"//button[@type='submit']/span[text()='{button}']")).Click();
        }

        [When(@"user click on button ""(.*)"" in opened popup")]
        public void WhenUserClickOnButtonInOpenedPopup(string checkout)
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            driver.Driver.FindElement(By.CssSelector($"a[title='{checkout}']")).Click();
        }

        [Then(@"In cart shown previously choosed options for both of products")]
        public void ThenInCartShownPreviouslyChoosedOptionsForBothOfProducts()
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("cart_summary")));

            string cartName1 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(1)>.cart_description>p>a")).Text;
            Assert.That(name1, Is.EqualTo(cartName1));

            string cartName2 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(2)>.cart_description>p>a")).Text;
            Assert.That(name2, Is.EqualTo(cartName2));

            string cartColorAndSize1 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(1)>.cart_description>small>a")).Text;
            Assert.That(cartColorAndSize1, Contains.Substring(color1).And.Contains(size1));

            string cartColorAndSize2 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(2)>.cart_description>small>a")).Text;
            Assert.That(cartColorAndSize2, Contains.Substring(color2).And.Contains(size2));

            string cartAmount1 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(1) input[type='text']")).GetAttribute("value");
            Assert.That(amount1, Is.EqualTo(cartAmount1));

            string cartAmount2 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(2) input[type='text']")).GetAttribute("value");
            Assert.That(amount2, Is.EqualTo(cartAmount2));

            string cartUnitPrice1 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(1) span.price>span")).Text;
            Assert.That(unitPrice1, Is.EqualTo(cartUnitPrice1));

            string cartUnitPrice2 = driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(2) span.price>span")).Text;
            Assert.That(unitPrice2, Is.EqualTo(cartUnitPrice2));


            double cartTotal1 = Convert.ToDouble(driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(1) td.cart_total>span")).Text.Trim('$'));
            Assert.That(totalPrice1, Is.EqualTo(cartTotal1));

            double cartTotal2 = Convert.ToDouble(driver.Driver.FindElement(By.CssSelector("tbody>:nth-child(2) td.cart_total>span")).Text.Trim('$'));
            Assert.That(totalPrice2, Is.EqualTo(cartTotal2));
        }

    }
}
