using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjectRefactor.Components;

namespace PageObjectRefactor.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        private const string Url = "http://www.amazon.com";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        public HomePage Open()
        {
            _driver.Navigate().GoToUrl(Url);
            return this;
        }

        public NavigationMenu NavigationMenu()
        {
            return new NavigationMenu(_driver);
        }
    }
}
