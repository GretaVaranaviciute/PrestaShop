using NUnit.Framework;

namespace Prestashop.Test
{
    class PrestaTest : BaseTest
    {

        [TestCase("Cushion", "Name", "Surname", "test@mail.com", "51 Street", "55555", "City", "France")]
        public static void PurchaseItem(string Product, string Name, string Surname, string Email, string Address, string Zip, string City, string Country)
        {
            prestaHomePage.NavigateToPage();
            prestaHomePage.SearchProduct(Product);
            prestaHomePage.VerifyFoundItem(Product);
            prestaHomePage.AddItem();
            orderPage.FillPersonalInfo(Name, Surname, Email);
            orderPage.FillAddressInfo(Address, Zip, City, Country);
            orderPage.VeriffyPaymentOptions();
            orderPage.VeriffyOrderConfirmation();
        }


    }
}

