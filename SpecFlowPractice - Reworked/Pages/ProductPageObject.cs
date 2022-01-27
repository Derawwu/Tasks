using OpenQA.Selenium;
using SpecFlowPractice.Helpers;
using System.Collections.Generic;

namespace SpecFlowPractice.Pages
{
    class ProductPageObject : BasePageObject
    {

        public string PageMainTitleText()
        {
            var result = webDriver.FindElement(By.CssSelector("h1.catalog-heading")).Text;
            return result;
        }

        public void Sorting()
        {
            webDriver.FindElement(By.CssSelector("select.select-css")).Click();
            webDriver.FindElement(By.CssSelector("option[value='2: expensive']")).Click();
        }

        public List<string> AddProductToCart(int productNumber)
        {
            webDriver.FindElement(By.CssSelector($"ul>:nth-child({productNumber}).catalog-grid__cell button.buy-button")).Click();
            var productName = webDriver.FindElement(By.CssSelector($"ul>:nth-child({productNumber}).catalog-grid__cell a.goods-tile__heading")).Text;
            var productPrice = HTML_Helpers.ScrubHtml(webDriver.FindElement(By.CssSelector($"ul>:nth-child({productNumber}).catalog-grid__cell span.goods-tile__price-value")).Text);
            List<string> productInfo = new();
            productInfo.Add(productName);
            productInfo.Add(productPrice);
            return productInfo;
        }

        public void OpenCart()
        {
            webDriver.FindElement(By.CssSelector("rz-cart.header-actions__component>:first-child")).Click();
        }

        public List<string> InfoAboutProductAlreadyAddedToTheCart()
        {
            var productName = webDriver.FindElement(By.CssSelector("a.cart-product__title")).Text;
            var productPrice = webDriver.FindElement(By.CssSelector($".cart-receipt__sum-price>span")).Text;
            List<string> productInfo = new();
            productInfo.Add(productName);
            productInfo.Add(productPrice);
            return productInfo;
        }
    }
}