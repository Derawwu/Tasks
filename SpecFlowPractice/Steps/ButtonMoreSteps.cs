﻿
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
    public sealed class ButtonMoreSteps
    {
        public WebDriverDriver driver { get; }

        public ButtonMoreSteps(WebDriverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"user enters to search bar text ""(.*)"" and press search button")]
        public void GivenUserEntersToSearchBarTextAndPressSearchButton(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys(searchRequest);
            driver.Driver.FindElement(By.Name("submit_search")).Click();
        }

        [Given(@"click on button More")]
        public void GivenClickOnButtonMore()
        {
            var productCard = driver.Driver.FindElement(By.CssSelector("ul.product_list.grid.row>:first-child"));
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(productCard).Perform();
            driver.Driver.FindElement(By.CssSelector
                ("li>div>div>div.button-container>a.button.lnk_view.btn.btn-default>span")).Click();
        }

        [Given(@"user choose quantity='(.*)', size='(.*)', color=white")]
        public void GivenUserChooseQuantitySizeColorWhite(int amount, char size)
        {
            driver.Driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.Driver.FindElement(By.Id("quantity_wanted")).SendKeys(Convert.ToString(amount));

            driver.Driver.FindElement(By.Id("group_1")).Click();
            driver.Driver.FindElement(By.CssSelector($"#group_1>option[title={size}]")).Click();

            driver.Driver.FindElement(By.Id("color_8")).Click();
        }

        [When(@"user click on button ""(.*)""")]
        public void WhenUserClickOnButton(string button)
        {
            driver.Driver.FindElement(By.XPath($"//button[@type='submit']/span[text()='{button}']")).Click();
        }

        [Then(@"PopUp with success message is displayed")]
        public void ThenPopUpWithSuccessMessageIsDisplayed()
        {
            WebDriverWait driverWait = new WebDriverWait(driver.Driver, TimeSpan.FromSeconds(10));
            driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#layer_cart")));

            var message = driver.Driver.FindElement(By.CssSelector("#layer_cart >.clearfix>.layer_cart_product >h2"));
            Assert.IsNotEmpty(message.Text);
        }

    }
}