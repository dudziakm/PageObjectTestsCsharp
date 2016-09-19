using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObjectRefactor.PageObjects
{
    public class ProductDetailsPAge 
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;


        [FindsBy(How = How.Id, Using = "productTitle")]
        private IWebElement ProductTitleField { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        private IWebElement AddToCartButton { get; set; }

        public ProductDetailsPAge(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        public string GetProductTitle()
        {
            return ProductTitleField.Text;
        }

        public AddToCartConfirmPage AddToCart()
        {
            AddToCartButton.Click();
            return new AddToCartConfirmPage(_driver);
        }

    }
}
