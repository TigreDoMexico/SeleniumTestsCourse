using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoEfetuarRegistro : UITest
    {
        private RegistroPO register;

        public AoEfetuarRegistro(UITestFixture fixture) : base(fixture)
        {
            driver = fixture.Driver;
            register = new RegistroPO(driver);
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaAgradecimentos()
        {
            // Arrange
            register.AcessarHome();
            register.PreencherValores("David Tigre", "david.tigre@gmail.com", "123", "123");

            // Act
            register.SubmeterForm();

            // Assert
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "david.tigre@gmail.com", "123", "123")]
        [InlineData("David Tigre", "david.tigre", "123", "123")]
        [InlineData("David Tigre", "david.tigre@gmail.com", "123", "456")]
        [InlineData("David Tigre", "david.tigre@gmail.com", "123", "")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(string nome, string email, string senha, string confirmSenha)
        {
            // Arrange
            register.AcessarHome();
            register.PreencherValores(nome, email, senha, confirmSenha);

            // Act
            register.SubmeterForm();

            // Assert
            Assert.Contains("section-registro", driver.PageSource);
        }
    }
}
