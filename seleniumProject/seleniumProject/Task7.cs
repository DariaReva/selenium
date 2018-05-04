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

            IList<IWebElement> menu = Browser.FindElement(By.XPath(".//*[@id='box-apps-menu-wrapper']")).FindElements(By.TagName("a"));
            List<string> HrefObj = new List<string>();
            foreach (var element in menu)
                HrefObj.Add(element.GetAttribute("href"));
            
            for (int i = 0; i < menu.Count; i++)
                Browser.Navigate().GoToUrl(HrefObj[i]);
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
