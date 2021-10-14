
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.PageObjects.DTO;
using OpenQA.Selenium;
using System;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoCadastrarLeilao
    {
        private IWebDriver driver;
        private NovoLeilaoPO register;

        public AoCadastrarLeilao(UITestFixture fixture)
        {
            driver = fixture.Driver;
            register = new NovoLeilaoPO(driver);

            // ACESSAR COMO ADMIN
            var loginRegister = new LoginPO(driver);
            
            loginRegister.AcessarHome();
            loginRegister.PreencherValores("admin@example.org", "123");

            loginRegister.SubmeterForm();
        }

        [Fact]
        public void DadoValoresValidosDeveIrParaListagem()
        {
            // Arrange
            register.AcessarNovoLeilao();
            register.PreencherFormulario(new LeilaoDTO {
                Titulo = "Leilão Teste",
                Descricao = "Lorem Ipsum",
                Categoria = "Item de Colecionador",
                ValorInicial = 4000d,
                Imagem = @"E:\Projects\AluraCourse\SeleniumTestsCourse\Alura.LeilaoOnline.WebApp\wwwroot\images\painting1.jpg",
                InicioPregao = DateTime.Now.AddDays(20),
                TerminoPregao = DateTime.Now.AddDays(50),
            });

            // Act
            register.SubmeteFormulario();

            // Assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
