using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prestashop.Page
{
   public class PrestaHomePage : BasePage
    {
        private const string PageAddress = "https://demo.prestashop.com/#/en/front";
        private IWebElement searchBox => Driver.FindElement(By.XPath("//input[@name='s']"));
        private IWebElement addButton => Driver.FindElement(By.XPath("//button[@class='btn btn-primary add-to-cart']"));
        private IWebElement itemNameInModal => Driver.FindElement(By.XPath("//h6[@class='h6 product-name']"));
        private IWebElement itemName => Driver.FindElement(By.XPath("//h1[@class='h1']"));
        private IWebElement proceedToCheckoutButton => Driver.FindElement(By.XPath("//a[@class='btn btn-primary']"));
        IReadOnlyCollection<IWebElement> productList => Driver.FindElements(By.XPath("//a[@itemprop='url']"));

        public PrestaHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void SearchProduct(string Product)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='loadingMessage']")));
            
            Driver.SwitchTo().Frame(0);

            searchBox.Clear();
            searchBox.SendKeys(Product);
            searchBox.SendKeys(Keys.Enter);
        }
            
        public void VerifyFoundItem(string Product)
        { 
            foreach(IWebElement item in productList)
            {
                Assert.IsTrue(item.Text.Contains(Product));
            }
            productList.ElementAt(0).Click();
        }

        public void AddItem()
        {
            addButton.Click();
            itemNameInModal.Click();
            Assert.AreEqual(itemName.Text, itemNameInModal.Text.ToUpper());
            proceedToCheckoutButton.Click();
            proceedToCheckoutButton.Click();
        }


    }
}
