using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO : PageObject
    {
        private By byLogoutLink;
        private By byMeuPerfilLink;

        public MenuLogadoPO(IWebDriver driver) : base(driver)
        {
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            // Criar a Ação
            IAction acaoLogout = new Actions(driver)
                .MoveToElement(linkMeuPerfil)
                .MoveToElement(linkLogout)
                .Click()
                .Build();

            // Executar a Ação
            acaoLogout.Perform();
        }
    }
}
