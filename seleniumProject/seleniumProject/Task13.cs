using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task13
    {
        IWebDriver Browser = new OpenQA.Selenium.Firefox.FirefoxDriver();

        [TestInitialize]
        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }

        public void Check(String a, String b)
        {
            if (a != b)
                throw new Exception();
        }

        bool AreElementsPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TestMethod]
        public void TestMethod7()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            IWebElement item = Browser.FindElement(By.XPath(".//*[@id='box-most-popular']/div/ul/li[1]/a[1]"));
            item.Click();
            IWebElement cart = Browser.FindElement(By.XPath(".//*[@id='box-product']/div[2]/div[2]/div[5]/form/table/tbody/tr/td/button"));
            cart.Click();

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
