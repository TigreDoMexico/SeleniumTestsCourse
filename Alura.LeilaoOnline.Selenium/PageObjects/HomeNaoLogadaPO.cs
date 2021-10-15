using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    class HomeNaoLogadaPO : PageObject
    {
        public MenuNaoLogadoPO Menu { get; set; }

        public HomeNaoLogadaPO(IWebDriver driver) : base(driver)
        {
            Menu = new MenuNaoLogadoPO(driver);
        }

        public void AcessarHome() => driver.Navigate().GoToUrl("http://localhost:5000");
    }
}
