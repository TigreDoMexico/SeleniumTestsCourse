using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoEfetuarLogin : UITest
    {
        private LoginPO register;

        public AoEfetuarLogin(UITestFixture fixture) : base(fixture)
        {
            register = new LoginPO(driver);
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            // Arrange
            register.AcessarTelaLogin();
            register.PreencherValores("david.tigre@gmail.com", "123");

            // Act
            register.RealizarLogin();

            // Assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {
            // Arrange
            register.AcessarTelaLogin();
            register.PreencherValores("david.tigre@gmail.com", "");

            // Act
            register.RealizarLogin();

            // Assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void DadoLoginRealizadoDeveIrParaHomeNaoLogada()
        {
            // Arrange
            RealizarLogin("david.tigre@gmail.com", "123");

            var dashboardRegister = new DashboardPO(driver);

            // Act - Efetuar Logout
            dashboardRegister.Menu.EfetuarLogout();

            // Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

    }
}
