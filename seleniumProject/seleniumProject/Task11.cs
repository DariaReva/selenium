using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Text;

namespace seleniumProject
{
    [TestClass]
    public class Task11
    {
        IWebDriver Browser;
        
        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            //Browser = new FirefoxDriver();
            //Browser = new InternetExplorerDriver();
            Browser.Manage().Window.Maximize();
        }

        string GenRandomString(string Email, int Length)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Email.Length - 1);
                sb.Append(Email[Position]);
            }
            return sb.ToString();
        }

        bool IsElementPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }


        [TestMethod]
        public void Test11()
        {
            //регистрация
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/create_account");
            IWebElement input = Browser.FindElement(By.XPath(".//input[@name = 'firstname']"));
            input.SendKeys("Ivan");
            input = Browser.FindElement(By.XPath(".//input[@name = 'lastname']"));
            input.SendKeys("Ivanov");
            input = Browser.FindElement(By.XPath(".//input[@name = 'address1']"));
            input.SendKeys("Nizhniy Novgorod");
            input = Browser.FindElement(By.XPath(".//input[@name = 'postcode']"));
            input.SendKeys("999999");
            input = Browser.FindElement(By.XPath(".//input[@name = 'city']"));
            input.SendKeys("Nizhniy Novgorod");
            input = Browser.FindElement(By.XPath(".//input[@name = 'email']"));
            string Email = GenRandomString("abcdefgABCDEFG12345", 4);
            input.SendKeys(Email);
            input.SendKeys("@");
            input.SendKeys(Email);
            input = Browser.FindElement(By.XPath(".//input[@name = 'phone']"));
            input.SendKeys("+79027867894");
            input = Browser.FindElement(By.XPath(".//input[@name = 'password']"));
            string password = "Plate1234";
            input.SendKeys(password);
            input = Browser.FindElement(By.XPath(".//input[@name = 'confirmed_password']"));
            input.SendKeys(password);
            input = Browser.FindElement(By.XPath(".//button[@type = 'submit']"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//a[contains(text(), 'Logout')]"));
            input.Click();

            //повторная авторизация
            //Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            IWebElement input1 = Browser.FindElement(By.XPath(".//input[@name = 'email']"));
            input1.SendKeys(Email);
            input1.SendKeys("@");
            input1.SendKeys(Email);
            input1 = Browser.FindElement(By.XPath(".//input[@name = 'password']"));
            input1.SendKeys(password);
            input1 = Browser.FindElement(By.XPath(".//button[@type = 'submit']"));
            input1.Click();
            if (IsElementPresent(Browser, By.XPath(".//div[contains(@class, 'success')]")) != true)
                Assert.Fail("Log in failed");
            input1 = Browser.FindElement(By.XPath(".//a[contains(text(), 'Logout')]"));
            input1.Click();

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
