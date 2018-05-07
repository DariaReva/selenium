using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Linq;

namespace seleniumProject
{
    [TestClass]
    public class Task13
    {
        IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
        }

        public int NumFromStr (string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]+", ""));
        }

        bool IsElementPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TestMethod]
        public void Test13()
        {
            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));

            for (int i = 0; i < 3; i++)
            {
                Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
                IWebElement item = Browser.FindElement(By.XPath(".//li[contains(@class, 'product')]"));
                item.Click();
                item = Browser.FindElement(By.XPath(".//span[@class = 'quantity']"));
                string text = item.GetAttribute("textContent");
                if (IsElementPresent(Browser, By.XPath(".//select[@name = 'options[Size]']")))
                {
                    item = Browser.FindElement(By.XPath(".//select[@name = 'options[Size]']"));
                    item.Click();
                    item = Browser.FindElement(By.XPath(".//option[@value = 'Medium']"));
                    item.Click();
                }
                item = Browser.FindElement(By.XPath(".//button[@name = 'add_cart_product']"));
                item.Click();
                wait.Until(ExpectedConditions.TextToBePresentInElement(
                    Browser.FindElement(By.XPath(".//span[@class = 'quantity']")),
                    (NumFromStr(text) + 1).ToString()));
                item = Browser.FindElement(By.XPath(".//span[@class = 'quantity']"));
                item.Click();
            }

            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            IWebElement cart = Browser.FindElement(By.XPath(".//a[contains(@class, 'link')]"));
            cart.Click();

            for (int i = 0; i < 3; i++)
            {
                List<IWebElement> ducks = Browser.FindElements(By.XPath(".//table[contains(@class, 'dataTable')]//td[@class = 'item']")).ToList();
                if (ducks.Count != 0)
                {
                    IWebElement last = ducks[ducks.Count - 1];
                    IWebElement input = Browser.FindElement(By.XPath(".//strong[contains(text(), '$')]"));
                    wait.Until(d => d.FindElement(By.XPath(".//button[@name = 'remove_cart_item']")));
                    IWebElement button = Browser.FindElement(By.XPath(".//button[@name = 'remove_cart_item']"));
                    button.Click();
                    wait.Until(ExpectedConditions.StalenessOf(last));
                }
            }

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
