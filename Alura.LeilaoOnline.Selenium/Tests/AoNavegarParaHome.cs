using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;
        private RegistroPO register;

        public AoNavegarParaHome(UITestFixture fixture)
        {
            driver = fixture.Driver;
            register = new RegistroPO(driver);
        }
        
        [Fact]
        public void DadoChromeAbertoMostrarLeiloesNoTitulo()
        {
            // ARRANGE

            // ACT
            register.AcessarHome();

            // ASSERT
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoMostrarProximosLeiloesNaPagina()
        {
            // ARRANGE

            // ACT
            register.AcessarHome();

            // ASSERT
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoNaoExibirErroNoForm()
        {
            // Arrange
            register.AcessarHome();

            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            // ACT && ASSERT
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
