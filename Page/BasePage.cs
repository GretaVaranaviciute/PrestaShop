using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Prestashop.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
