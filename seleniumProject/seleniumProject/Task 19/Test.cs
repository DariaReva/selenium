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
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test19()
        {
            Cart cart = new Cart();
            cart.Initialize();
            for (int i = 0; i < 3; i++)
            {
                cart.ChooseElement();
                cart.AddToCart();
            }
            cart.GoToCart(cart.URL , By.XPath(cart.locator));
            for (int i = 0; i < 3; i++)
                cart.RemoveElement();
            cart.Quit();
        }
    }
}
