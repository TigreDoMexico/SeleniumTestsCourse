using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using Alura.LeilaoOnline.Selenium.PageObjects.Helpers;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltrosLeiloesPO : PageObject
    {
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltrosLeiloesPO(IWebDriver driver) : base(driver)
        {
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
    }
}
