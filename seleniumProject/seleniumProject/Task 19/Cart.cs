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

namespace seleniumProject.Task_19
{
    public class Cart : Application
    {
        public string URL;
        public string locator;
        
        public Cart()
        {
            URL = "http://localhost/litecart/en/";
            locator = ".//a[contains(@class, 'link')]";
        }
        public void GoToCart(string URL, By locator)
        {
            Browser.Navigate().GoToUrl(URL);
            Browser.FindElement(locator).Click();
        }

        public void ChooseElement()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            Browser.FindElement(By.XPath(".//li[contains(@class, 'product')]")).Click();
        }

        public void AddToCart()
        {
            IWebElement item = Browser.FindElement(By.XPath(".//span[@class = 'quantity']"));
            string text = item.GetAttribute("textContent");
            if (IsElementPresent(Browser, By.XPath(".//select[@name = 'options[Size]']")))
            {
                Browser.FindElement(By.XPath(".//select[@name = 'options[Size]']")).Click();
                Browser.FindElement(By.XPath(".//option[@value = 'Medium']")).Click();
            }
            Browser.FindElement(By.XPath(".//button[@name = 'add_cart_product']")).Click();
            wait.Until(ExpectedConditions.TextToBePresentInElement(
                Browser.FindElement(By.XPath(".//span[@class = 'quantity']")),
                (NumFromStr(text) + 1).ToString()));
            Browser.FindElement(By.XPath(".//span[@class = 'quantity']")).Click();
        }

        public void RemoveElement()
        {
            List<IWebElement> ducks = Browser.FindElements(By.XPath(".//table[contains(@class, 'dataTable')]//td[@class = 'item']")).ToList();
            if (ducks.Count != 0)
            {
                IWebElement last = ducks[ducks.Count - 1];
                Browser.FindElement(By.XPath(".//strong[contains(text(), '$')]"));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//button[@name = 'remove_cart_item']")));
                Browser.FindElement(By.XPath(".//button[@name = 'remove_cart_item']")).Click();
                wait.Until(ExpectedConditions.StalenessOf(last));
            }
        }
    }

}
