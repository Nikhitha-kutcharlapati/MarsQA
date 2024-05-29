using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace MarsTask1.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public CommonDriver()
        {

        }
        public CommonDriver(IWebDriver driver)
        {
            this.driver = driver;

        }
        public IWebDriver Initialize()
        {
            driver = new ChromeDriver();
            return driver;
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

    }
}
