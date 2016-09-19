using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjectRefactor.PageObjects;

namespace PageObjectRefactor.Components
{
    public class NavigationMenu
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        //candidate tab
        [FindsBy(How = How.Id, Using = @"searchDropdownBox")]
        private IWebElement SearchDropdownBox { get; set; }


        [FindsBy(How = How.Id, Using = @"twotabsearchtextbox")]
        private IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = @"//*[@value='Go']")]
        private IWebElement SearchGoButton { get; set; }

        [FindsBy(How = How.Id, Using = @"nav-cart-count")]
        private IWebElement NavigationItemCart { get; set; }

        public NavigationMenu(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        public SearchResultsPage SearchFor(string category, string searchKey)
        {
            new SelectElement(_driver.FindElement(By.Id("searchDropdownBox"))).SelectByText(category);
            // Write: Selenium
            SearchInput.SendKeys(searchKey);
            // Click Go button
            SearchGoButton.Click();
            return new SearchResultsPage(_driver);
        }

        public CartPage OpenBasket()
        {
            NavigationItemCart.Click();
            return new CartPage(_driver);
        }

    }
}
