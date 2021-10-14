using Alura.LeilaoOnline.Selenium.PageObjects.Contract;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardPO : IProductFormObject
    {
        private IWebDriver driver;

        public DashboardPO(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcessarHome()
        {
            throw new NotImplementedException();
        }

        public void SubmeterForm()
        {
            throw new NotImplementedException();
        }
    }
}
