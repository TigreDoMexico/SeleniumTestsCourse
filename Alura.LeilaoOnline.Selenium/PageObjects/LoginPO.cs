using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;

        private By byInputLogin;
        private By byInputSenha;
        
        private By byBotaoSubmit;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoSubmit = By.Id("btnLogin");            
        }

        public void PreencherValores(string login, string senha)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputSenha).SendKeys(senha);
        }

        public LoginPO AdicionarLogin(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO AdicionarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO AcessarTelaLogin()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO RealizarLogin()
        {
            driver.FindElement(byBotaoSubmit).Submit();
            return this;
        }
    }
}
