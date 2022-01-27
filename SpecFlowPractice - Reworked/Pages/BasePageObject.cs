using OpenQA.Selenium;
using SpecFlowPractice.Hooks;
using SpecFlowPracticeReworked.Drivers;
using System;

namespace SpecFlowPractice.Pages
{
    public class BasePageObject 
    {
        protected static Hook Hook;
        protected IWebDriver webDriver = Hook.webDriver;

        public void SearchBar(string searchRequest)
        {
            
            var searchBar = webDriver.FindElement(By.CssSelector("input.search-form__input"));
            searchBar.Clear();
            searchBar.SendKeys(searchRequest);
            webDriver.FindElement(By.CssSelector("button.search-form__submit")).Click();
        }
        
    }
}
