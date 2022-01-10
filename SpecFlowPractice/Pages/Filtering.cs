using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowPractice.Steps
{
    class Filtering
    {
        public WebDriverChrome driver { get; }

        public Filtering(WebDriverChrome driver)
        {
            this.driver = driver;
        }


        public void HigherPriceFirst()
        {
            List<IWebElement> Items = null;
            List<IWebElement> ItemsNew = new();
            Items = driver.Driver.FindElements(By.CssSelector(".content_price")).ToList();
            foreach (IWebElement item in Items)
            {

                if (item.Displayed)
                {
                    ItemsNew.Add(item);
                }
            }

            List<IWebElement> RawPrice = new();
            foreach (IWebElement itemsNew in ItemsNew)
            {
                List<IWebElement> Raw = new();
                Raw = itemsNew.FindElements(By.CssSelector(" span")).ToList();

                if (Raw.Count() == 3)
                {
                    RawPrice.Add(Raw[1]);
                }
                else
                {
                    RawPrice.Add(Raw[0]);
                }
            }

            List<double> RefinedPrice = new();
            foreach (IWebElement raw in RawPrice)
            {
                string refined = raw.Text;
                RefinedPrice.Add(Convert.ToDouble(refined.Trim('$')));
            }

            var RefinedPriceSorted = RefinedPrice.OrderByDescending(i => i);

            Assert.That(RefinedPrice, Is.EqualTo(RefinedPriceSorted));

            Console.WriteLine();









        }


    }
}




/*[Given(@"User enters to search bar text '(.*)' and press button enter")]
        public void GivenUserEntersToSearchBarText(string searchRequest)
        {
            IWebElement searchTab = driver.Driver.FindElement(By.Id("search_query_top"));
            searchTab.SendKeys("summer");
            searchTab.SendKeys(Keys.Enter);
        }

       [Given(@"Click on dropdown with filtering option")]
        public void GivenClickOnDropdownWithFilteringOption()
        {
            IWebElement dropdown = driver.Driver.FindElement(By.Id("selectProductSort"));
            dropdown.Click();
        }

        [When(@"choosed option ""(.*)""")]
        public void WhenChoosedOption(string priceDesc)
        {
            driver.Driver.FindElement(By.XPath("//option[@value='price:desc'] ")).Click();
        }

        [Then(@"appropriate layout of items should be displayed")]
        public void ThenAppropriateLayoutOfItemsShouldBeDisplayed()
        {
            Filtering filtering = new();
            filtering.HigherPriceFirst();
        }*//*






        [Given(@"Click on dropdown with filtering option")]
        public void GivenClickOnDropdownWithFilteringOption()
        {
            IWebElement dropdown = driver.Driver.FindElement(By.Id("selectProductSort"));
            dropdown.Click();
        }

        [When(@"choosed option ""(.*)""")]
        public void WhenChoosedOption(string p0)
        {
            driver.Driver.FindElement(By.XPath("//option[@value='price:desc'] ")).Click();
        }

        [Then(@"appropriate layout of items should be displayed")]
        public void ThenAppropriateLayoutOfItemsShouldBeDisplayed()
        {
            Filtering filtering = new();
            filtering.HigherPriceFirst();
        }
*/