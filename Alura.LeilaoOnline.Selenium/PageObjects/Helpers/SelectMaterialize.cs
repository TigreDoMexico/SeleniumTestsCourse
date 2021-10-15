using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;

        public IEnumerable<IWebElement> Options { get; }

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;

            selectWrapper = driver.FindElement(locatorSelectWrapper);
            Options = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        private void OpenWrapper() => selectWrapper.Click();

        private void LoseFocus() => selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);

        public void DeselectAll()
        {
            OpenWrapper();
            Options.ToList().ForEach(o => o.Click());
            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            Options.Where(op => op.Text.Contains(option))
                       .ToList().ForEach(o => o.Click());
            LoseFocus();
        }
    }
}
