using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task8
    {
        IWebDriver Browser = new OpenQA.Selenium.Firefox.FirefoxDriver();

        [TestInitialize]
        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }
        bool AreElementsPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TestMethod]
        public void TestMethod3()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            
            IList<IWebElement> NewItem = Browser.FindElement(By.XPath(".//*[@id='main']/div[2]/div[2]")).FindElements(By.CssSelector("[class *= 'new']"));
            IList<IWebElement> SaleItem = Browser.FindElement(By.XPath(".//*[@id='main']/div[2]/div[2]")).FindElements(By.CssSelector("[class *= 'sale']"));
            IList<IWebElement> Item = Browser.FindElement(By.XPath(".//*[@id='main']/div[2]/div[2]")).FindElements(By.ClassName("image"));


            int StickerCount = NewItem.Count + SaleItem.Count;
            int ItemCount = Item.Count;

            if (StickerCount != ItemCount)
                throw new Exception();
            
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
