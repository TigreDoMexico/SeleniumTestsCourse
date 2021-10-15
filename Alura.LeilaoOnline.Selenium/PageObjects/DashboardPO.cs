using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using Alura.LeilaoOnline.Selenium.PageObjects.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public DashboardPO(IWebDriver driver)
        {
            this.driver = driver;

            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");

            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");

            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PreencherDadosFiltro(FiltroLeilaoDTO data)
        {
            driver.FindElement(byInputTermo).SendKeys(data.Termo);

            if (data.IsEmAndamento)
                driver.FindElement(byInputAndamento).Click();

            // SELECT CATEGORIAS
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();
            data.Categorias.ForEach(c => select.SelectByText(c));
        }

        public void SubmeterPesquisa() => driver.FindElement(byBotaoPesquisar).Click();

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
