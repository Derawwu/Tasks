using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutoTests
{
    [TestFixture]
    public class Tests
    {
        static readonly IWebDriver webDriver = new ChromeDriver();
        [SetUp]
        public void BeforeTestRun()
        {
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [Test]
        public void Test1()
        {
           
            var myTitle = webDriver.Title;
            Console.WriteLine(myTitle);
        }
        [Test]
        public void Test2()
        {
            var tab1 = webDriver.FindElement(By.CssSelector(".sf-menu.clearfix.menu-content.sf-js-enabled.sf-arrows>li>a[title='Women']"));
            var tab2 = webDriver.FindElement(By.CssSelector(".sf-menu.clearfix.menu-content.sf-js-enabled.sf-arrows>li>a[title='Dresses']"));
            var tab3 = webDriver.FindElement(By.CssSelector(".sf-menu.clearfix.menu-content.sf-js-enabled.sf-arrows>li>a[title='T-shirts']"));

            Console.WriteLine(tab1.Text);
            Console.WriteLine(tab2.Text);
            Console.WriteLine(tab3.Text);
        }
        [Test]
        public void Test3()
        {
            var searchTab = webDriver.FindElement(By.Id("search_query_top"));
            Console.WriteLine(searchTab.GetAttribute("name"));
        }
        [Test]
        public void Test4()
        {
            webDriver.FindElement(By.CssSelector("li>.blockbestsellers")).Click();
           
        }
        [Test]
        public void Test5()
        {
            webDriver.FindElement(By.Id("search_query_top")).SendKeys("summer");
            webDriver.FindElement(By.Id("search_query_top")).SendKeys(Keys.Enter);
        }
    }
}