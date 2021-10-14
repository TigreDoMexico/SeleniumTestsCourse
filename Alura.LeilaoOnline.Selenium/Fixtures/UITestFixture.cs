using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class UITestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        // SETUP
        public UITestFixture()
        {
            Driver = new ChromeDriver(".");
        }

        // TEAR DOWN
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
