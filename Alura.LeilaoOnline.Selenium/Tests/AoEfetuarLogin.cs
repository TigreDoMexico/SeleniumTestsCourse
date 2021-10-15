using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;
        private LoginPO register;

        public AoEfetuarLogin(UITestFixture fixture)
        {
            driver = fixture.Driver;
            register = new LoginPO(driver);
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            // Arrange
            register.AcessarHome();
            register.PreencherValores("david.tigre@gmail.com", "123");

            // Act
            register.SubmeterForm();

            // Assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {
            // Arrange
            register.AcessarHome();
            register.PreencherValores("david.tigre@gmail.com", "");

            // Act
            register.SubmeterForm();

            // Assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void DadoLoginRealizadoDeveIrParaHomeNaoLogada()
        {
            // Arrange
            register.AcessarHome();
            register.PreencherValores("david.tigre@gmail.com", "123");
            register.SubmeterForm();

            var dashboardRegister = new DashboardPO(driver);

            // Act - Efetuar Logout
            dashboardRegister.EfetuarLogout();

            // Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

    }
}
