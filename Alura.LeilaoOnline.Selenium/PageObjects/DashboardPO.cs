using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using Alura.LeilaoOnline.Selenium.PageObjects.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardPO : PageObject
    {

        public FiltrosLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardPO(IWebDriver driver) : base(driver)
        {
            Filtro = new FiltrosLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }
    }
}
