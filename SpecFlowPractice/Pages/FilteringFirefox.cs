using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowPractice.Pages
{
    class FilteringFirefox
    {
        public WebDriverFirefox driverFirefox { get; }

        public FilteringFirefox(WebDriverFirefox driverFirefox)
        {
            this.driverFirefox = driverFirefox;
        }


        public void HigherPriceFirst()
        {
            List<IWebElement> Items = null;
            List<IWebElement> ItemsNew = new();
            Items = driverFirefox.Driver.FindElements(By.CssSelector(".content_price")).ToList();
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
