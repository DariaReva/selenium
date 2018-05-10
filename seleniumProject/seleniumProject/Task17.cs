using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using System.Text.RegularExpressions;
using System.Linq;

namespace seleniumProject
{
    [TestClass]
    public class Task17
    {
        public IWebDriver Chrome;
        public IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            Chrome = new ChromeDriver();
            Browser = new EventFiringWebDriver(Chrome);
            Browser.Manage().Window.Maximize();
        }
        public int NumFromStr(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]+", ""));
        }
        

        [TestMethod]
        public void Test17()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/");
            IWebElement input_login = Browser.FindElement(By.XPath(".//input[@name = 'username']"));
            input_login.Click();
            input_login.SendKeys("admin");

            IWebElement input_password = Browser.FindElement(By.XPath(".//input[@name = 'password']"));
            input_password.Click();
            input_password.SendKeys("admin");

            IWebElement enter = Browser.FindElement(By.XPath(".//button[@name = 'login']"));
            enter.Click();

            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1");

            IWebElement input = Browser.FindElement(By.XPath(".//a[contains(text(), 'Subcategory')]"));
            input.Click();
            List<IWebElement> items = Browser.FindElements(By.XPath(".//a[contains(@href, 'product&category') and contains(text(), 'Duck')]")).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                items = Browser.FindElements(By.XPath(".//a[contains(@href, 'product&category') and contains(text(), 'Duck')]")).ToList();
                items[i].Click();
                List<LogEntry> logs = Browser.Manage().Logs.GetLog("browser").ToList();
                Assert.IsTrue(logs.Count > 0);
                Browser.Navigate().Back();
            }

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
