using OpenQA.Selenium.Remote;

namespace AutoWebFramework.Base
{
    public class ParallelConfig
    {

        public RemoteWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }
    }
}
