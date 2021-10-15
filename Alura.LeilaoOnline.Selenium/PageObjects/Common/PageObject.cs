using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public abstract class PageObject
    {
        protected IWebDriver driver;

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
