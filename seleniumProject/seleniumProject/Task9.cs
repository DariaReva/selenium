using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;

namespace seleniumProject
{
    [TestClass]
    public class Task9
    {
        IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            //Browser = new InternetExplorerDriver();
            Browser.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Test9()
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

            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
            List<IWebElement> Countries = Browser.FindElements(By.XPath(".//td[@id = 'content']//a")).ToList();
            List<IWebElement> SortedCountries = Browser.FindElements(By.XPath(".//td[@id = 'content']//a")).ToList();
            SortedCountries.Sort();

            bool equal = SortedCountries.SequenceEqual(Countries);
            if (equal != true)
                Assert.Fail("Wrong order");
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
