using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO : PageObject
    {
        private readonly By byMenuMobile;

        public MenuNaoLogadoPO(IWebDriver driver) : base(driver)
        {
            byMenuMobile = By.CssSelector(".sidenav-trigger");
        }

        public bool MenuMobileVisible => driver.FindElement(byMenuMobile).Displayed;
    }
}