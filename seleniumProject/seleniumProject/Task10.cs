using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace seleniumProject
{
    [TestClass]
    public class Task10
    {
        IWebDriver Browser;

        [TestInitialize]
        public void Initialize()
        {
            Browser = new ChromeDriver();
            //Browser = new InternetExplorerDriver();
            Browser.Manage().Window.Maximize();
        }
       
        public void CheckGrey(string Color)
        {
            List<string> sub = new List<string>(Color.Split(','));
            List<int> rgba = new List<int>();
            foreach (var element in sub)
                rgba.Add(Convert.ToInt32(Regex.Replace(element, @"[^\d]+", "")));
            for (int i = 0; i < (rgba.Count - 2); i++)
            {
                if (rgba[i] != rgba[i + 1])
                    Assert.Fail("Wrong color");
            }
        }

        public void CheckRed(string Color)
        {
            List<string> sub = new List<string>(Color.Split(','));
            List<int> rgba = new List<int>();
            foreach (var element in sub)
                rgba.Add(Convert.ToInt32(Regex.Replace(element, @"[^\d]+", "")));
            if (rgba[1] != 0 && rgba[2] != 0)
                Assert.Fail("Wrong color");
        }

        public void CheckTextDecoration(string TextDecoration, string style)
        {
            List<string> sub = new List<string>(TextDecoration.Split(' '));
            if (sub[0] != style)
                Assert.Fail("Wrong style");
        }

        [TestMethod]
        public void Test10()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            IWebElement item = Browser.FindElement(By.XPath(".//div[@id='box-campaigns']//a"));
            string Pointer = item.GetAttribute("href");
            string MainName = Browser.FindElement(By.XPath(".//div[contains(text(), 'Yellow Duck')]")).GetAttribute("textContent");

            IWebElement MainPrice = Browser.FindElement(By.XPath(".//s[contains(@class,'price')]"));
            string MainPriceText = MainPrice.GetAttribute("textContent");

            string MainPriceColor = MainPrice.GetCssValue("color");
            CheckGrey(MainPriceColor);
            
            string MainPriceStyle = MainPrice.GetCssValue("text-decoration");
            CheckTextDecoration(MainPriceStyle, "line-through");

            double PriceSize = Convert.ToInt32(Regex.Replace(MainPrice.GetCssValue("font-size"), @"[^\d]+", "")); //исправить преобразование

            IWebElement MainCampaign = Browser.FindElement(By.XPath(".//strong[contains(@class, 'price')]"));
            string MainCampaignText = MainCampaign.GetAttribute("textContent");

            string MainCampaignColor = MainCampaign.GetCssValue("color");
            CheckRed(MainCampaignColor);

            string MainCampaignStyle = MainCampaign.GetCssValue("text-decoration");
            CheckTextDecoration(MainCampaignStyle, "none");

            item.Click();

            Assert.AreEqual(Pointer, "http://localhost/litecart/en/rubber-ducks-c-1/subcategory-c-2/yellow-duck-p-1");

            IWebElement NewItem = Browser.FindElement(By.XPath(".//h1[contains(text(), 'Yellow Duck')]"));
            string Name = NewItem.GetAttribute("textContent");

            IWebElement Price = Browser.FindElement(By.XPath(".//s[contains(@class, 'regular')]"));
            string PriceText = Price.GetAttribute("textContent");
            string PriceColor = Price.GetCssValue("color");
            CheckGrey(PriceColor);
            string PriceStyle = Price.GetCssValue("text-decoration");
            CheckTextDecoration(PriceStyle, "line-through");

            IWebElement Campaign = Browser.FindElement(By.XPath(".//strong[contains(@class, 'campaign')]"));
            string CampaignText = Campaign.GetAttribute("textContent");
            string CampaignColor = Campaign.GetCssValue("color");
            CheckRed(CampaignColor);
            string CampaignStyle = Campaign.GetCssValue("text-decoration");
            CheckTextDecoration(CampaignStyle, "none");

            Assert.AreEqual(MainName, Name);
            Assert.AreEqual(MainPriceText, PriceText);
            Assert.AreEqual(MainCampaignText, CampaignText);
        }
        [TestCleanup]
        public void Quit()
        {
            Browser.Quit();
        }
    }
}
