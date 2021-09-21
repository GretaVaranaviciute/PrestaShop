using Prestashop.Drivers;
using Prestashop.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Prestashop.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static OrderPage orderPage;
        public static PrestaHomePage prestaHomePage;


        [OneTimeSetUp]
        public static void SetUp() 
        {
            driver = CustomDriver.GetChromeDriver();


            prestaHomePage = new PrestaHomePage(driver);
            orderPage = new OrderPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}

