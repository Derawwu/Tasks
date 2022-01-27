using BoDi;
using OpenQA.Selenium;
using SpecFlowPractice.Hooks;
using SpecFlowPracticeReworked.Drivers;
using System;

namespace SpecFlowPractice.Pages
{
    public class BasePageObject 
    {
        protected static IObjectContainer container;
        protected static Hook hook = new Hook(container);
        protected IWebDriver webDriver = hook.Driver;

        public void SearchBar(string searchRequest)
        {
            var searchBar = webDriver.FindElement(By.CssSelector("input.search-form__input"));
            searchBar.Clear();
            searchBar.SendKeys(searchRequest);
            webDriver.FindElement(By.CssSelector("button.search-form__submit")).Click();
        }
        
    }
}
