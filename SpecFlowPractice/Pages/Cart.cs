using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowPractice.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Pages
{
    class Cart
    {
        private static string priceInMemory;
        private static string nameInMemory;
        public WebDriverDriver driver { get; }

        public Cart(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        public Cart()
        {
        }

        public void SavePriceAndAddToTheCart()
        {
            priceInMemory = driver.Driver.FindElement(By.CssSelector("ul>:first-child div.right-block>:nth-child(3)>span.price")).Text ;

            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));

            nameInMemory = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child a.product-name")).Text;

            var productCard = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(productCard).Perform();
            driver.Driver.FindElement(By.CssSelector("ul>:first-child div.right-block>div.button-container>:first-child>span")).Click();



            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            driver.Driver.FindElement(By.CssSelector("a.btn.btn-default.button.button-medium")).Click();
        }

        public void PriceAndNameCheckout()
        {
            string cartPrice;
            string cartName;

            cartPrice = driver.Driver.FindElement(By.CssSelector("td.cart_total>span")).Text;

            cartName = driver.Driver.FindElement(By.CssSelector("td.cart_description>p>a")).Text;


            Assert.That(cartPrice, Is.EqualTo(priceInMemory));
            Assert.That(cartName, Is.EqualTo(nameInMemory));

        }
    }
}
