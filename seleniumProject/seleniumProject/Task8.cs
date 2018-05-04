using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task8
    {
        IWebDriver Browser; 

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
        }
        bool IsElementPresent(IWebElement driver, By locator)
        {
            return driver.FindElements(locator).Count == 1;
        }

        [TestMethod]
        public void Test8()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");

            IList<IWebElement> Product = Browser.FindElements(By.XPath(".//li[contains(@class, 'product')]"));

            for (int i = 0; i < Product.Count; i++)
            {
                if (IsElementPresent(Product[i], By.XPath(".//div[contains(@class, 'sticker')]")) != true)
                    Assert.Fail();
            }

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
