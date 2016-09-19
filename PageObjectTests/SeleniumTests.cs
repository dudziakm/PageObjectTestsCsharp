using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PageObjectTests
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver _driver;

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
            // Open main page
            _driver.Navigate().GoToUrl("http://www.amazon.com");

            // Select Books
            new SelectElement(_driver.FindElement(By.Id("searchDropdownBox"))).SelectByText("Books");
            // Write: Selenium
            _driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Selenium");
            // Click Go button
            _driver.FindElement(By.XPath("//*[@value='Go']")).Click();

            // Get first book
            IWebElement firstItemTitleElement = _driver.FindElement(By.XPath("//h2[contains(@class, 's-access-title')]"));
            string firstItemTitle = firstItemTitleElement.Text;
            firstItemTitleElement.Click();

            // title on a product page:
            Assert.AreEqual(_driver.FindElement(By.Id("productTitle")).Text, firstItemTitle);

            // add to cart:
            _driver.FindElement(By.Id("add-to-cart-button")).Click();

            Assert.True(_driver.FindElement(By.XPath("//h1[@class='a-size-medium a-text-bold']")).Text.Contains("Added to Cart"));

            // Click Cart:
            _driver.FindElement(By.Id("nav-cart-count")).Click();

            //Check if book is added:
            Assert.True(_driver.FindElement(By.XPath(@"(//span[@class='a-size-medium sc-product-title a-text-bold'])[1]")).Text.Contains(firstItemTitle));
        }
    }
}
