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
    public class SearchResultsPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        //candidate tab
        [FindsBy(How = How.ClassName, Using = "s-access-title")]
        private IWebElement SearchResultItemTitle { get; set; }


        public SearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
        }

        public string GetFirstResultTitle()
        {
            return SearchResultItemTitle.Text;
        }

        public ProductDetailsPAge clickFirstResultTitle()
        {
            SearchResultItemTitle.Click();
            return new ProductDetailsPAge(_driver);
        }




    }
}
