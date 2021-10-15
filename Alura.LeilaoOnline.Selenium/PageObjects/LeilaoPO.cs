using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LeilaoPO
    {
        private IWebDriver driver;
        private readonly By byLanceAtual;
        private readonly By byInputValor;
        private readonly By byBotaoFazOferta;

        public LeilaoPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputValor = By.Id("Valor");
            byBotaoFazOferta = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public double LanceAtual => double.Parse(
                    driver.FindElement(byLanceAtual).Text,
                    System.Globalization.NumberStyles.Currency);

        public void VisitarLeilao(int idLeilao) => driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        
        internal void OfertarLance(double value)
        {
            driver.FindElement(byInputValor).SendKeys(value.ToString());
            driver.FindElement(byBotaoFazOferta).Click();
        }
    }
}
