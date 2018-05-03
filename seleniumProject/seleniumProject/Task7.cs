﻿using System;
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
        bool AreElementsPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
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

            IList<IWebElement> menu = Browser.FindElement(By.Id("box-apps-menu")).FindElements(By.TagName("a"));
            string[] HrefObj = new string[menu.Count];
            for (int i = 0; i < menu.Count; i++)
                HrefObj[i] = menu[i].GetAttribute("href");
            for (int i = 0; i < menu.Count; i++)
            {
                Browser.Navigate().GoToUrl(HrefObj[i]);
            }
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}