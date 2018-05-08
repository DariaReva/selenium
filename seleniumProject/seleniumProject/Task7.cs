using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task7
    {
        IWebDriver Browser; 

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
        }

        bool IsElementPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TestMethod]
        public void Test7()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/");
            IWebElement input_login = Browser.FindElement(By.Name("username"));
            input_login.Click();
            input_login.SendKeys("admin");

            IWebElement input_password = Browser.FindElement(By.Name("password"));
            input_password.Click();
            input_password.SendKeys("admin");

            IWebElement enter = Browser.FindElement(By.Name("login"));
            enter.Click();

            IList<IWebElement> menu = Browser.FindElements(By.XPath(".//*[@id='box-apps-menu-wrapper']//a"));
            IList<IWebElement> menu1 = Browser.FindElements(By.XPath(".//*[contains(@id, 'doc-')]//a"));

            for (int i = 0; i < menu.Count; i++)
            {
                menu = Browser.FindElements(By.XPath(".//*[@id = 'app-']"));
                menu[i].Click();
                
                menu = Browser.FindElements(By.XPath(".//*[@id = 'app-']"));
                menu1 = Browser.FindElements(By.XPath(".//*[contains(@id, 'doc-')]"));
                if (menu1.Count > 0)
                {
                    for(int j = 0; j < menu1.Count; j++)
                    {
                        menu = Browser.FindElements(By.XPath(".//*[@id = 'app-']"));
                        menu1 = Browser.FindElements(By.XPath(".//*[contains(@id, 'doc-')]"));
                        menu1[j].Click();
                        Assert.IsTrue(IsElementPresent(Browser, By.CssSelector("h1")));
                    }
                }
                else
                    Assert.IsTrue(IsElementPresent(Browser, By.CssSelector("h1")));
            }
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
