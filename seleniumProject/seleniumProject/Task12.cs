using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task12
    {
        IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
        }

        public void Check(String a, String b)
        {
            if (a != b)
                throw new Exception();
        }

        bool AreElementsPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TestMethod]
        public void TestMethod6()
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

            IWebElement input = Browser.FindElement(By.CssSelector("[href*='http://localhost/litecart/admin/?app=catalog&doc=catalog']"));
            input.Click();

            input = Browser.FindElement(By.XPath(".//*[@id='content']/div[1]/a[2]"));
            input.Click();

            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[1]/td/label[1]/input"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[2]/td/span/input"));
            input.SendKeys("Name");
            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[3]/td/input"));
            input.SendKeys("Code");
            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[7]/td/div/table/tbody/tr[4]/td[1]/input"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[8]/td/table/tbody/tr/td[1]/input"));
            input.Clear();
            input.SendKeys("3");
            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[10]/td/input"));
            input.SendKeys("2018-01-20");
            input = Browser.FindElement(By.XPath(".//*[@id='tab-general']/table/tbody/tr[11]/td/input"));
            input.SendKeys("2018-03-19");

            input = Browser.FindElement(By.XPath(".//*[@id='content']/form/div/ul/li[2]/a"));
            input.Click();

            input = Browser.FindElement(By.XPath(".//*[@id='tab-information']/table/tbody/tr[3]/td/input"));
            input.SendKeys("name");
            input = Browser.FindElement(By.XPath(".//*[@id='tab-information']/table/tbody/tr[6]/td/span/input"));
            input.SendKeys("Title");

            input = Browser.FindElement(By.XPath(".//*[@id='content']/form/div/ul/li[4]/a"));
            input.Click();

            input = Browser.FindElement(By.XPath(".//*[@id='tab-prices']/table[1]/tbody/tr/td/input"));
            input.Clear();
            input.SendKeys("15");
            input = Browser.FindElement(By.XPath(".//*[@id='tab-prices']/table[1]/tbody/tr/td/select"));
            input.Click();
            input = Browser.FindElement(By.CssSelector("[value *= 'EUR']"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//*[@id='tab-prices']/table[3]/tbody/tr[2]/td[2]/input"));
            input.SendKeys("26");

            IWebElement input1 = Browser.FindElement(By.XPath(".//*[@id='content']/form/p/span/button[1]"));
            input1.Click();

            AreElementsPresent(Browser, By.XPath(".//*[@id='content']/form/table/tbody/tr[4]/td[3]"));
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
