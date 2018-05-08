using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
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
            //Browser = new FirefoxDriver();
            Browser.Manage().Window.Maximize();
        }
       
        public void CheckGrey(string Color)
        {
            List<string> sub = new List<string>(Color.Split(','));
            List<int> rgba = new List<int>();
            foreach (var element in sub)
                rgba.Add(Convert.ToInt32(Regex.Replace(element, @"[^\d]+", "")));
            if (rgba.Count == 2)
                rgba.Add(1);
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

        public void CheckFontSize (string font1, string font2)
        {
            List<string> sub1 = new List<string>(font1.Split('.'));
            List<int> size1 = new List<int>();
            foreach (var element in sub1)
                size1.Add(Convert.ToInt32(Regex.Replace(element, @"[^\d]+", "")));

            List<string> sub2 = new List<string>(font2.Split('.'));
            List<int> size2 = new List<int>();
            foreach (var element in sub2)
                size2.Add(Convert.ToInt32(Regex.Replace(element, @"[^\d]+", "")));

            if (size1[0] >= size2[0])
                Assert.Fail("Wrong size");
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

            string MainPriceSize = MainPrice.GetCssValue("font-size");

            IWebElement MainCampaign = Browser.FindElement(By.XPath(".//strong[contains(@class, 'price')]"));
            string MainCampaignText = MainCampaign.GetAttribute("textContent");

            string MainCampaignColor = MainCampaign.GetCssValue("color");
            CheckRed(MainCampaignColor);

            string MainCampaignStyle = MainCampaign.GetAttribute("tagName");
            CheckTextDecoration(MainCampaignStyle, "STRONG");

            string MainCampaignSize = MainCampaign.GetCssValue("font-size");

            CheckFontSize(MainPriceSize, MainCampaignSize);

            item.Click();

            Assert.AreEqual(Pointer, "http://localhost/litecart/en/rubber-ducks-c-1/subcategory-c-2/yellow-duck-p-1");

            IWebElement newitem = Browser.FindElement(By.XPath(".//h1[@class = 'title']"));
            string Name = newitem.GetAttribute("textContent");

            IWebElement Price = Browser.FindElement(By.XPath(".//s[contains(@class, 'regular')]"));
            string PriceText = Price.GetAttribute("textContent");
            string PriceColor = Price.GetCssValue("color");
            CheckGrey(PriceColor);
            string PriceStyle = Price.GetCssValue("text-decoration");
            CheckTextDecoration(PriceStyle, "line-through");
            string PriceSize = Price.GetCssValue("font-size");

            IWebElement Campaign = Browser.FindElement(By.XPath(".//strong[contains(@class, 'campaign')]"));
            string CampaignText = Campaign.GetAttribute("textContent");
            string CampaignColor = Campaign.GetCssValue("color");
            CheckRed(CampaignColor);
            string CampaignStyle = Campaign.GetAttribute("tagName");
            CheckTextDecoration(CampaignStyle, "STRONG");
            string CampaignSize = Campaign.GetCssValue("font-size");

            CheckFontSize(PriceSize, CampaignSize);

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
