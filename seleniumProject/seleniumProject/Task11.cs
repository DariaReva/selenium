using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace seleniumProject
{
    [TestClass]
    public class Task11
    {
        IWebDriver Browser = new OpenQA.Selenium.Firefox.FirefoxDriver();
        
        [TestInitialize]
        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }

        public void Check(String a, String b)
        {
            if (a != b)
                throw new Exception();
        }

        [TestMethod]
        public void TestMethod5()
        {
            //регистрация
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/create_account");
            IWebElement input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[2]/td[1]/input"));
            input.SendKeys("Ivan");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[2]/td[2]/input"));
            input.SendKeys("Ivanov");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[3]/td[1]/input"));
            input.SendKeys("Nizhniy Novgorod");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[4]/td[1]/input"));
            input.SendKeys("999999");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[4]/td[2]/input"));
            input.SendKeys("Nizhniy Novgorod");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[6]/td[1]/input"));
            input.SendKeys("revadariya@yandex.ru");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[6]/td[2]/input"));
            input.SendKeys("+79027867894");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[8]/td[1]/input"));
            input.SendKeys("Plate1234");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[8]/td[2]/input"));
            input.SendKeys("Plate1234");
            input = Browser.FindElement(By.XPath(".//*[@id='create-account']/div/form/table/tbody/tr[9]/td/button"));
            input.Click();
            input = Browser.FindElement(By.XPath(".//*[@id='box-account']/div/ul/li[4]/a"));
            input.Click();

            //повторная авторизация
            //Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            IWebElement input1 = Browser.FindElement(By.XPath(".//*[@id='box-account-login']/div/form/table/tbody/tr[1]/td/input"));
            input1.SendKeys("revadariya@yandex.ru");
            input1 = Browser.FindElement(By.XPath(".//*[@id='box-account-login']/div/form/table/tbody/tr[2]/td/input"));
            input1.SendKeys("Plate1234");
            input1 = Browser.FindElement(By.XPath(".//*[@id='box-account-login']/div/form/table/tbody/tr[4]/td/span/button[1]"));
            input1.Click();
            input1 = Browser.FindElement(By.XPath(".//*[@id='box-account']/div/ul/li[4]/a"));
            input1.Click();

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
