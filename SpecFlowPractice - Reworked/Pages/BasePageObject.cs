using OpenQA.Selenium;
using SpecFlowPractice.Drivers;
using SpecFlowPractice.Hooks;
using System;

namespace SpecFlowPractice.Pages
{
    class BasePageObject : WebDriverSettings
    {
        public void SearchBar(string searchRequest)
        {
            var searchBar = Driver.FindElement(By.CssSelector("input.search-form__input"));
            searchBar.Clear();
            searchBar.SendKeys(searchRequest);
            Driver.FindElement(By.CssSelector("button.search-form__submit")).Click();
        }
    }
}
