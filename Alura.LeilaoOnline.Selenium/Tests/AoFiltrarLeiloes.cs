using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoFiltrarLeiloes : UITest
    {
        private DashboardPO register;

        public AoFiltrarLeiloes(UITestFixture fixture) : base(fixture)
        {
            driver = fixture.Driver;
            register = new DashboardPO(driver);

            // ACESSAR ÁREA DOS FILTROS
            RealizarLogin("david.tigre@gmail.com", "123");
        }

        [Fact]
        public void DadoInformacoesParaPesquisaDeveMostrarPainelResultado()
        {
            // ARRANGE
            register.Filtro.PreencherDadosFiltro(new FiltroLeilaoDTO
            {
                Categorias = new List<string> { "Arte", "Coleção" },
                Termo = "",
                IsEmAndamento = true
            }
            );

            // ACT
            register.Filtro.SubmeterPesquisa();

            // ASSERT
            Assert.Contains("Resultado da pesquisa", driver.PageSource);
        }
    }
}
