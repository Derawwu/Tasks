using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPractice.Drivers;
using System;

namespace SpecFlowPractice.Pages
{
    class CartFirefox
    {
        private static string priceInMemory;
        private static string nameInMemory;
        public WebDriverFirefox driverFirefox { get; }

        public CartFirefox(WebDriverFirefox driverFirefox)
        {
            this.driverFirefox = driverFirefox;
        }

        public CartFirefox()
        {
        }

        public void SavePriceAndAddToTheCart()
        {
            priceInMemory = driverFirefox.Driver.FindElement(By.CssSelector("ul>:first-child div.right-block>:nth-child(3)>span.price")).Text;

            WebDriverWait driverWait = new WebDriverWait(driverFirefox.Driver, TimeSpan.FromSeconds(10));

            nameInMemory = driverFirefox.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child a.product-name")).Text;

            var productCard = driverFirefox.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driverFirefox.Driver);
            action.MoveToElement(productCard).Perform();
            driverFirefox.Driver.FindElement(By.CssSelector("ul>:first-child div.right-block>div.button-container>:first-child>span")).Click();



            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            driverFirefox.Driver.FindElement(By.CssSelector("a.btn.btn-default.button.button-medium")).Click();
        }

        public void PriceAndNameCheckout()
        {
            string cartPrice;
            string cartName;

            cartPrice = driverFirefox.Driver.FindElement(By.CssSelector("td.cart_total>span")).Text;

            cartName = driverFirefox.Driver.FindElement(By.CssSelector("td.cart_description>p>a")).Text;


            Assert.That(cartPrice, Is.EqualTo(priceInMemory));
            Assert.That(cartName, Is.EqualTo(nameInMemory));

        }
    }
}
