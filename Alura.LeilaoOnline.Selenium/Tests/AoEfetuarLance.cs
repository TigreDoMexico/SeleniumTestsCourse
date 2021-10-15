using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoEfetuarLance : UITest
    {
        private LeilaoPO register;

        public AoEfetuarLance(UITestFixture fixture) : base(fixture)
        {
            RealizarLogin("david.tigre@gmail.com", "123"); 
            register = new LeilaoPO(driver);
        }

        [Fact]
        public void DadoLoginInteressadoDeveAtualizarLance()
        {
            // Arrange
            register.VisitarLeilao(1);
            
            // Act
            register.OfertarLance(5001);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => register.LanceAtual == 5001);

            // Assert
            Assert.True(iguais);
        }
    }
}
