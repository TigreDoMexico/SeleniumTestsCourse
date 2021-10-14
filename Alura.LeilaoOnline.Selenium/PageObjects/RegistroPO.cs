using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver driver;

        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;

        private By byFormRegistro;
        private By byBotaoSubmit;

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");

            byBotaoSubmit = By.Id("btnRegistro");
            byFormRegistro = By.TagName("form");
        }

        public void PreencherValores(string nome, string email, string senha, string confirmSenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
        }

        public void AcessarHome() => driver.Navigate().GoToUrl("http://localhost:5000");
        public void SubmeterForm() => driver.FindElement(byBotaoSubmit).Click();
    }
}
