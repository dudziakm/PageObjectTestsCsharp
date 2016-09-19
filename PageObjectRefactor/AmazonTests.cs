using System.CodeDom;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectRefactor.PageObjects;

namespace PageObjectRefactor
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [SetUp]
        public void TestSetup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }

        [Test]
        public void FirstTest()
        {
            const string bookTitle = "Mastering Selenium WebDriver";

            // Open main page
            _homePage = new HomePage(_driver).Open();
            var searchResultsPage = _homePage.NavigationMenu().SearchFor("Books", "Selenium");
            
            // Get first book
            var productPage =  searchResultsPage.clickFirstResultTitle();

            // title on a product page:
            Assert.AreEqual(productPage.GetProductTitle(), bookTitle);            

            // add to cart:
            var addConfirmPage = productPage.AddToCart();

            // added to cart:
            addConfirmPage.ConfirmationText();
            Assert.True(addConfirmPage.ConfirmationText().Contains("Added to Cart"));

            // Click Cart:
            var basket = addConfirmPage.NavigationMenu().OpenBasket();
            
            //Check if book is added:
            Assert.True(basket.GetFirstItemText().Contains(bookTitle));            
        }
    }
}
