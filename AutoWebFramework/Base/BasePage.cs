using AutoWebFramework.Extensions;
using AutoWebFramework.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoWebFramework.Base
{
    public abstract class BasePage : Base
    {
        public BasePage(ParallelConfig parellelConfig) : base(parellelConfig)
        {
        }

        public By liveloSpinner => By.Id("livelo-spinner");

        public By notification => By.CssSelector("div.notifi__container");

        public void WaitLiveloSipnner()
        {
            var liveloSinnerWeb = _parallelConfig.Driver.FindElement(liveloSpinner);

            WebDriverExtensions.WaitUntilAttributeValueEquals(_parallelConfig.Driver, liveloSinnerWeb, "disabled", null);
            WebDriverExtensions.WaitUntilAttributeValueEquals(_parallelConfig.Driver, liveloSinnerWeb, "style", "display: none;");
        }

        public void CloseCookieNotification()
        {
            try
            {
                var closeIcon = _parallelConfig.Driver.FindElement(notification).FindElement(By.CssSelector("span.icon-x"));
                closeIcon.Click();
            }
            catch (NoSuchElementException)
            {
            }
        }
    }
}
