using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace seleniumProject
{
    [TestClass]
    public class Task10
    {
        IWebDriver Browser = new OpenQA.Selenium.Firefox.FirefoxDriver();

        [TestInitialize]
        public void Initialize()
        {
            Browser.Manage().Window.Maximize();
        }
       
        [TestMethod]
        public void TestMethod4()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            IWebElement item = Browser.FindElement(By.XPath(".//*[@id='box-campaigns']/div/ul/li/a[1]"));
            string Pointer = item.GetAttribute("href");
            string MainName = Browser.FindElement(By.XPath(".//*[@id='box-campaigns']/div/ul/li/a[1]/div[2]")).GetAttribute("textContent");

            IWebElement MainPrice = Browser.FindElement(By.XPath(".//*[@id='box-campaigns']/div/ul/li/a[1]/div[4]/s"));
            string MainPriceText = MainPrice.GetAttribute("textContent");
            string MainPriceColor = MainPrice.GetAttribute("color");
            string MainPriceStyle = MainPrice.GetAttribute("text-decoration");
            
            IWebElement MainCampaign = Browser.FindElement(By.XPath(".//*[@id='box-campaigns']/div/ul/li/a[1]/div[4]/strong"));
            string MainCampaignText = MainCampaign.GetAttribute("textContent");
            string MainCampaignColor = MainCampaign.GetAttribute("color");
            string MainCampaignStyle = MainCampaign.GetAttribute("text-decoration");

            item.Click();

            Assert.AreEqual(Pointer, "http://localhost/litecart/en/rubber-ducks-c-1/subcategory-c-2/yellow-duck-p-1");

            IWebElement NewItem = Browser.FindElement(By.XPath(".//*[@id='box-product']/div[1]/h1"));
            string Name = NewItem.GetAttribute("textContent");

            IWebElement Price = Browser.FindElement(By.XPath(".//*[@id='box-product']/div[2]/div[2]/div[2]/s"));
            string PriceText = Price.GetAttribute("textContent");
            string PriceColor = Price.GetAttribute("color");
            string PriceStyle = Price.GetAttribute("text-decoration");

            IWebElement Campaign = Browser.FindElement(By.XPath(".//*[@id='box-product']/div[2]/div[2]/div[2]/strong"));
            string CampaignText = Campaign.GetAttribute("textContent");
            string CampaignColor = Campaign.GetAttribute("color");
            string CampaignStyle = Campaign.GetAttribute("text-decoration");

            Assert.AreEqual(MainName, Name);
            Assert.AreEqual(MainName, Name);
            Assert.AreEqual(MainPriceText, PriceText);
            Assert.AreEqual(MainPriceColor, PriceColor);
            Assert.AreEqual(MainPriceStyle, PriceStyle);
            Assert.AreEqual(MainCampaignText, CampaignText);
            Assert.AreEqual(MainCampaignColor, CampaignColor);
            Assert.AreEqual(MainCampaignStyle, CampaignStyle);

        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
