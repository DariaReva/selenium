using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace seleniumProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver Browser = new OpenQA.Selenium.Chrome.ChromeDriver();

        [TestInitialize]
        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }
        [TestMethod]
        public void TestMethod1()
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
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
