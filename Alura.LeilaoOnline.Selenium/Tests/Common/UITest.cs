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
    public abstract class UITest
    {
        protected IWebDriver driver { get; set; }

        public UITest(UITestFixture fixture)
        {
            driver = fixture.Driver;
        }

        protected void RealizarLogin(string login, string password)
        {
            LoginPO loginRegister = 
                new LoginPO(driver)
                    .AcessarTelaLogin()
                    .AdicionarLogin(login)
                    .AdicionarSenha(password)
                    .RealizarLogin();
        }
    }
}
