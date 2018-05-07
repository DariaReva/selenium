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
            List<string> HrefObj = new List<string>();
            foreach (var element in menu)
                HrefObj.Add(element.GetAttribute("href"));

            for (int i = 0; i < menu.Count; i++)
            {
                Browser.Navigate().GoToUrl(HrefObj[i]);
                IList<IWebElement> menu1 = Browser.FindElements(By.XPath(".//*[contains(@id, 'doc-')]//a"));
                List<string> HrefObj1 = new List<string>();
                foreach (var element1 in menu1)
                    HrefObj1.Add(element1.GetAttribute("href"));
                for (int j = 0; j < menu1.Count; j++)
                    Browser.Navigate().GoToUrl(HrefObj1[j]);
            }
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
