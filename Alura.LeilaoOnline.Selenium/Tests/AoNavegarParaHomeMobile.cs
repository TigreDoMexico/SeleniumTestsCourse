using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;
        private HomeNaoLogadaPO register;

        public AoNavegarParaHomeMobile()
        {
            var options = new ChromeOptions();
            var device = new ChromiumMobileEmulationDeviceSettings();
            device.Width = 400;
            device.Height = 800;
            device.UserAgent = "Customizada";

            options.EnableMobileEmulation(device);

            driver = new ChromeDriver(".", options);
            register = new HomeNaoLogadaPO(driver);
        }

        [Fact]
        public void DadaLargura400DeveMostrarMenuMobile()
        {
            // Arrange

            // Act
            register.AcessarHome();

            // Assert
            Assert.True(register.Menu.MenuMobileVisible);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            // TODO
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
