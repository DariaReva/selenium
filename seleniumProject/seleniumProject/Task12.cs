using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Html5;
using System.Threading;
using System.IO;

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
        public void Test12()
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

            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/?app=catalog&doc=catalog");

            IWebElement input = Browser.FindElement(By.XPath(".//a[contains(@href, 'http://localhost/litecart/admin/?category_id=0&app=catalog&doc=edit_product')]"));
            input.Click();

            input = Browser.FindElement(By.XPath(".//input[@value = '1']"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//input[@name = 'name[en]']"));
            input.SendKeys("Name");
            input = Browser.FindElement(By.XPath(".//input[@name = 'code']"));
            input.SendKeys("Code");
            input = Browser.FindElement(By.XPath(".//input[@value = '1-3']"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//input[@name = 'quantity']"));
            input.Clear();
            input.SendKeys("3");
            input = Browser.FindElement(By.XPath(".//input[@name = 'new_images[]']"));
            input.SendKeys(Directory.GetCurrentDirectory() + "//4-blue-duck-1.png");

            input = Browser.FindElement(By.XPath(".//input[@name = 'date_valid_from']"));
            input.SendKeys("2018-01-20");
            input = Browser.FindElement(By.XPath(".//input[@name = 'date_valid_to']"));
            input.SendKeys("2018-03-19");
            input = Browser.FindElement(By.XPath(".//a[@href = '#tab-information']"));
            input.Click();
            Thread.Sleep(100);

            input = Browser.FindElement(By.XPath(".//input[@name = 'keywords']"));
            input.SendKeys("name");
            input = Browser.FindElement(By.XPath(".//input[@name = 'head_title[en]']"));
            input.SendKeys("Title");

            input = Browser.FindElement(By.XPath(".//a[@href = '#tab-prices']"));
            input.Click();
            Thread.Sleep(100);

            input = Browser.FindElement(By.XPath(".//input[@name = 'purchase_price']"));
            input.Clear();
            input.SendKeys("15");
            input = Browser.FindElement(By.XPath(".//select[@name = 'purchase_price_currency_code']"));
            input.Click();
            input = Browser.FindElement(By.CssSelector("[value *= 'EUR']"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//input[@name = 'gross_prices[USD]']"));
            input.SendKeys("26");

            IWebElement input1 = Browser.FindElement(By.XPath(".//button[@name = 'save']"));
            input1.Click();

            if (AreElementsPresent(Browser, By.XPath(".//a[contains(@href, 'http://localhost/litecart/admin/?app=catalog&doc=edit_product&category_id=0&product_id')]")) == false)
                Assert.Fail("No items");

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
