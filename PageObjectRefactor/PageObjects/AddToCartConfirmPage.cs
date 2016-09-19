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
    public class AddToCartConfirmPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;


        [FindsBy(How = How.XPath, Using = "//h1[@class='a-size-medium a-text-bold']")]
        private IWebElement ConfirmTextField { get; set; }



        public AddToCartConfirmPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        public string ConfirmationText()
        {
            return ConfirmTextField.Text;
        }
        public NavigationMenu NavigationMenu()
        {
            return new NavigationMenu(_driver);
        }
    }
}
