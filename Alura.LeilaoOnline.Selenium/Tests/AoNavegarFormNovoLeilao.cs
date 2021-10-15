using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoNavegarFormNovoLeilao : UITest
    {
        private NovoLeilaoPO register;

        public AoNavegarFormNovoLeilao(UITestFixture fixture) : base(fixture)
        {
            driver = fixture.Driver;
            register = new NovoLeilaoPO(driver);

            // ACESSAR COMO ADMIN
            RealizarLogin("admin@example.org", "123");
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
