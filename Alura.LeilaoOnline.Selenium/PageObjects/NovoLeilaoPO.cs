using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using Alura.LeilaoOnline.Selenium.PageObjects.Helpers;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By byInputTitulo;
        private By byInputDescricao;
        private By bySelectCategoria;
        private By byInputValorInicial;

        private By byInputInicioPregao;
        private By byInputTerminoPregao;

        private By byInputImagem;

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(bySelectCategoria));
                return elementoCategoria.Options.Select(a => a.Text);

            }
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            bySelectCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");

            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");

            byInputImagem = By.Id("ArquivoImagem");
        }
        
        public void PreencherFormulario(LeilaoDTO data)
        {
            driver.FindElement(byInputTitulo).SendKeys(data.Titulo);
            driver.FindElement(byInputDescricao).SendKeys(data.Descricao);
            driver.FindElement(byInputValorInicial).SendKeys(data.ValorInicial.ToString());

            driver.FindElement(byInputInicioPregao).SendKeys(data.InicioPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(data.TerminoPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputImagem).SendKeys(data.Imagem);
            
            // SELECT CATEGORIA
            var select = new SelectMaterialize(driver, By.ClassName("select-wrapper"));
            select.SelectByText(data.Categoria);
        }

        public void SubmeteFormulario() => driver.FindElement(By.CssSelector("button[type=submit]")).Click();

        public void AcessarNovoLeilao() => driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
    }
}
