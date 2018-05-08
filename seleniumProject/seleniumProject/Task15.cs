using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Linq;

namespace seleniumProject
{
    [TestClass]
    public class Task15
    {
        IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            //Browser = new InternetExplorerDriver();
            //Browser = new FirefoxDriver();
            Browser.Manage().Window.Maximize();
        }

        
        [TestMethod]
        public void Test15()
        {
            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
