using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Linq;

namespace seleniumProject
{
    [TestClass]
    public class Task14
    {
        IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            //Browser = new InternetExplorerDriver();
            //Browser = new FirefoxDriver();
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
        }

        bool IsElementPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TestMethod]
        public void Test14()
        {
            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));

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

            IWebElement input = Browser.FindElement(By.XPath(".//a[@class = 'button']"));
            input.Click();

            List<IWebElement> windows = Browser.FindElements(By.XPath(".//i[contains(@class, 'fa-external-link')]")).ToList();
            for(int i = 0; i < windows.Count; i++)
            {
                windows = Browser.FindElements(By.XPath(".//i[contains(@class, 'fa-external-link')]")).ToList();
                string mainwindow = Browser.CurrentWindowHandle;
                List<string> identificators = Browser.WindowHandles.ToList();
                windows[i].Click();
                wait.Until(d => d.WindowHandles.Count > identificators.Count);
                identificators = Browser.WindowHandles.ToList();
                string newwindow = identificators[identificators.Count - 1];
                Browser.SwitchTo().Window(newwindow);
                Browser.Close();
                Browser.SwitchTo().Window(mainwindow);
            }
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
