using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task7
    {
        IWebDriver Browser = new OpenQA.Selenium.Firefox.FirefoxDriver();

        [TestInitialize]
        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }
        
        [TestMethod]
        public void TestMethod2()
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

            IList<IWebElement> menu = Browser.FindElements(By.XPath(".//*[@id='app-']/a"));
            for (int i = 0; i < menu.Count; i++)
            {
                menu[i].Click();
                IList<IWebElement> element = Browser.FindElements(By.CssSelector("[href*='http://localhost/litecart/admin/?app=']"));
                for (int j = 0; j < element.Count; j++)
                    element[j].Click();
                Browser.Navigate().GoToUrl("http://localhost/litecart/admin/");
            }
        }
        [TestCleanup]
        public void Quit()
        {
            //Browser.Quit();
        }
    }
}
