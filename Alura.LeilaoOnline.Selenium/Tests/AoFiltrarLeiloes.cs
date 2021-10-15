using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private readonly IWebDriver driver;
        private DashboardPO register;

        public AoFiltrarLeiloes(UITestFixture fixture)
        {
            driver = fixture.Driver;
            register = new DashboardPO(driver);

            // ACESSAR ÁREA DOS FILTROS
            LoginPO loginRegister = new LoginPO(driver);

            loginRegister.AcessarHome();
            loginRegister.PreencherValores("david.tigre@gmail.com", "123");

            loginRegister.SubmeterForm();
        }

        [Fact]
        public void DadoInformacoesParaPesquisaDeveMostrarPainelResultado()
        {
            // ARRANGE
            register.PreencherDadosFiltro(new FiltroLeilaoDTO
            {
                Categorias = new List<string> { "Arte", "Coleção" },
                Termo = "",
                IsEmAndamento = true
            }
            );

            // ACT
            register.SubmeterPesquisa();

            // ASSERT
            Assert.Contains("Resultado da pesquisa", driver.PageSource);
        }
    }
}
