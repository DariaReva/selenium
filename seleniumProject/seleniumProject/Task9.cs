using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
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
            //Browser = new ChromeDriver();
            //Browser = new InternetExplorerDriver();
            Browser = new FirefoxDriver();
            Browser.Manage().Window.Maximize();
        }

        public class SortedL : IComparable
        {
            protected string sort;

            public int CompareTo(object obj)
            {
                if (obj == null)
                    return 1;

                SortedL sort1 = obj as SortedL;
                if (sort != null)
                    return this.sort.CompareTo(sort1.sort);
                else
                    throw new ArgumentException();

            }
        }
        [TestMethod]
        public void Test9()
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

            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
            List<IWebElement> Countries = Browser.FindElements(By.XPath(".//td[@id = 'content']//a")).ToList();
            List<string> NameCountries = new List<string>();
            foreach (var element in Countries)
                NameCountries.Add(element.GetAttribute("textContent"));
            List<string> SortedCountries = NameCountries;
            SortedCountries.Sort();

            Assert.IsTrue(NameCountries.SequenceEqual(SortedCountries));
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
