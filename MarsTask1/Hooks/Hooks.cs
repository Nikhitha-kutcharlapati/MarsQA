using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsTask1.pages;
using MarsTask1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarsTask1.Hooks 
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            CommonDriver driverSetup = new CommonDriver();
            IWebDriver driver = driverSetup.Initialize();
            driver.Manage().Window.Maximize();
          

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }


        /* [BeforeScenario]
         public void OpenMars()
         {
             //Open Chrome/Firefox browser
             driver = new ChromeDriver();
             Thread.Sleep(1000);
         }*/

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }

        }

    }
}