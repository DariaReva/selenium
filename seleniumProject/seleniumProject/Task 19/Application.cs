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
    public class Application
    {
        public IWebDriver Browser;
        public WebDriverWait wait;

        public Application()
        {
            Browser = new ChromeDriver();
            //Browser = new InternetExplorerDriver();
            //Browser = new FirefoxDriver();
            wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
        }

        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }
        public int NumFromStr(string str)
        {
            return Convert.ToInt32(Regex.Replace(str, @"[^\d]+", ""));
        }
        public bool IsElementPresent(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        public void Quit()
        {
            Browser.Quit();
        }
    }
}
