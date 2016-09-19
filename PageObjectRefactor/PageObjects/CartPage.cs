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
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;


        [FindsBy(How = How.XPath, Using = @"(//span[@class='a-size-medium sc-product-title a-text-bold'])[1]")]
        private IWebElement ListItem { get; set; }
        
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        public string GetFirstItemText()
        {
            return ListItem.Text;
        }
    }
}
