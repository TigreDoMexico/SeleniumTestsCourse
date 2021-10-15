using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoNavegarFormNovoLeilao
    {
        private IWebDriver driver;
        private NovoLeilaoPO register;

        public AoNavegarFormNovoLeilao(UITestFixture fixture)
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
        public void DadoLoginAdministrativoDeveMostrar3Categorias()
        {
            //Arrange

            //Act
            register.AcessarNovoLeilao();

            //Assert
            Assert.Equal(3, register.Categorias.Count());
        }
    }
}
