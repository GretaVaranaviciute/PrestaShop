using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Prestashop.Page
{
    public class OrderPage : BasePage
    {
        private IWebElement firstNameInputField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        private IWebElement lastNameInputField => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        private IWebElement emailInputField => Driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement privacyCheckbox => Driver.FindElement(By.XPath("//input[@name='customer_privacy']"));
        private IWebElement termsAndConditionsCheckbox => Driver.FindElement(By.XPath("//input[@name='psgdpr']"));
        private IWebElement addressInputField => Driver.FindElement(By.XPath("//input[@name='address1']"));
        private IWebElement zipInputField => Driver.FindElement(By.XPath("//input[@name='postcode']"));
        private IWebElement cityInputField => Driver.FindElement(By.XPath("//input[@name='city']"));
        private SelectElement countryDropdown => new SelectElement (Driver.FindElement(By.XPath("//select[@class='form-control form-control-select js-country']")));
        private IWebElement confirmAddressButton => Driver.FindElement(By.XPath("//button[@name='confirm-addresses']"));
        private IWebElement continueButton => Driver.FindElement(By.XPath("//button[@class='continue btn btn-primary float-xs-right']"));
        private IWebElement confirmShippingButton => Driver.FindElement(By.XPath("//button[@name='confirmDeliveryOption']"));
        private IWebElement paymentOptionByCheck => Driver.FindElement(By.XPath("//label[@for='payment-option-1']"));
        private IWebElement paymentOptionByBank => Driver.FindElement(By.XPath("//label[@for='payment-option-2']"));
        private IWebElement agreeCheckbox => Driver.FindElement(By.XPath("//input[@id='conditions_to_approve[terms-and-conditions]']"));
        private IWebElement payByBankSelection => Driver.FindElement(By.Id("payment-option-2"));
        private IWebElement placeOrderButton => Driver.FindElement(By.XPath("//button[@class='btn btn-primary center-block']"));
        private IWebElement orderConfirmedMessage => Driver.FindElement(By.XPath("//h3[@class='h1 card-title']"));

        public OrderPage(IWebDriver webdriver) : base(webdriver) { }

        public void FillPersonalInfo(string Name, string Surname, string Email)
        {
            firstNameInputField.Clear();
            firstNameInputField.SendKeys(Name);

            lastNameInputField.Clear();
            lastNameInputField.SendKeys(Surname);

            emailInputField.Clear();
            emailInputField.SendKeys(Email);

            if (!privacyCheckbox.Selected)
                privacyCheckbox.Click();

            if (!termsAndConditionsCheckbox.Selected)
                termsAndConditionsCheckbox.Click();

            continueButton.Click();
        }
        public void FillAddressInfo(string Address, string Zip, string City, string Country)
        {
            addressInputField.Clear();
            addressInputField.SendKeys(Address);

            zipInputField.Clear();
            zipInputField.SendKeys(Zip);

            cityInputField.Clear();
            cityInputField.SendKeys(City);

            countryDropdown.SelectByText(Country);
            confirmAddressButton.Click();
            confirmShippingButton.Click();
        }

        public void VeriffyPaymentOptions()
        {
            Assert.IsTrue(paymentOptionByCheck.Text.Contains("Pay by Check"));
            Assert.IsTrue(paymentOptionByBank.Text.Contains("Pay by bank wire"));

            payByBankSelection.Click();

            if (!agreeCheckbox.Selected)
                agreeCheckbox.Click();
            
            placeOrderButton.Click();

        }

        public void VeriffyOrderConfirmation()
        {
            Assert.IsTrue(orderConfirmedMessage.Text.Contains("Your order is confirmed".ToUpper()));
        }

    }
}
