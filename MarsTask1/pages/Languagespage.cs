using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using MarsTask1.Hooks;
using MarsTask1.Utilities;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;


namespace MarsTask1.pages
{
    public class Languagespage : CommonDriver
    {
        public Languagespage(IWebDriver driver) : base(driver)
        {

        }
        public Languagespage()
        {

        }
        // defining webelements ***************************
        public IWebElement usernameTextbox => driver.FindElement(By.XPath("//input[contains(@placeholder,'Email address')]"));
        public IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[contains(@type,'password')]"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
        public IWebElement languagesButton => driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
        public IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        public IWebElement addLanguageTextbox => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
       public IWebElement chooseleveldropdown => driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));
        public IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        public IWebElement ToolTipMessage => driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public IWebElement EditLanguageTextbox => driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
        public IWebElement EditChooseLevelDropdown => driver.FindElement(By.XPath("//*[@class='ui dropdown']"));
        public IWebElement EditPencilIcon => driver.FindElement(By.XPath("//div[@id='account-profile-section']//form//table//tbody[2]/tr/td[3]/span[1]/i"));
        public IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement EditChooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + newLevel + \"']"));
        public IWebElement LastDeleteIcon => driver.FindElement(By.XPath("//table[1]/tbody[last()]//i[@class='remove icon']"));
        public IList<IWebElement> LanguageRows => driver.FindElements(By.XPath("//div[@data-tab='first']//table/tbody"));

        
            
        
        public void launchProfile(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Launch TurnUp portal and navigate to website login page
            string baseURL = "http://localhost:5000/Account/Profile";
            driver.Navigate().GoToUrl(baseURL);
        }
        public void userLogin(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Identify username and password 
            usernameTextbox.SendKeys("nikhitha.ic@gmail.com");
            passwordTextbox.SendKeys("Vicky@1020");
            //Just to wait for 5 seconds doing nothing and click on login button
            Thread.Sleep(3000);            
            loginButton.Click();
            Thread.Sleep(3000);


        }
        public void addlanguageAction(IWebDriver driver, String language, String level) {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Click on add new button
            addNewButton.Click();
            //WaitUtils.WaitToBeVisible(driver, "Xpath", "addNewButton", 10);


            // identify add language textbox and add language
            addLanguageTextbox.SendKeys(language);
            //Identify and select the language level
            SelectElement select = new SelectElement(chooseleveldropdown);
            select.SelectByValue(level);

        }
        public void addLanguage(IWebDriver driver)
        {

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Now add the language in the list

            Actions actions = new Actions(driver);
            actions.MoveToElement(addButton).Click().Perform();

        }
        public void EditLanguageRecord(string oldLanguage, string newLanguage, string oldLevel, string newLevel)
        {
           
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Profile");

            // click edit pencil icon for the existing record
            WaitUtils.WaitToBeVisible(driver, "Xpath", "EditPencilIcon", 5);
            EditPencilIcon.Click();

            if (newLanguage.Length > 0)
            {
                for (int i = 1; i <= LanguageRows.Count; i++)
                {
                    String getLanguageName = driver.FindElement(By.XPath($"//div[@data-tab='first']//table/tbody[{i}]/tr/td[1]")).Text;
                    
                    Console.WriteLine( " ***************************************************"+ getLanguageName);

                    if (getLanguageName == oldLanguage)
                    {

                        IWebElement specificUpdateIcon = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i}]/tr/td[3]/span[1]/i"));
                        specificUpdateIcon.Click();
                        EditLanguageTextbox.Clear();
                        EditLanguageTextbox.SendKeys(newLanguage);
                        

                    }
                }
               
            }
            

            if (newLevel.Length > 0)
            {
                EditChooseLevelDropdown.Click();
                WaitUtils.WaitToBeVisible(driver, "Xpath", "EditChooseLevelDropdown", 5);

                IWebElement EditChooseLevelOption = driver.FindElement(By.XPath("//*[@value='" + newLevel + "']"));
                EditChooseLevelOption.Click();

            }

            WaitUtils.WaitToBeVisible(driver, "Xpath", "UpdateButton", 5);
            UpdateButton.Click();

        }
        //To Delete Last Language records
        public void DeleteLastLanguageRecords()
        {
            LastDeleteIcon.Click();
        }

        //To Delete specific Language records
        public void DeletespecificLanguageRecords(string newLanguage)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Profile");
           

            for (int i = 1; i <= LanguageRows.Count; i++)
            {
                var getLanguageName = driver.FindElement(By.XPath($"//div[@data-tab='first']//table/tbody[{i}]/tr/td[1]")).Text;

                if (getLanguageName == newLanguage)
                {
                    IWebElement specificDeleteIcon = driver.FindElement(By.XPath($"//table[1]/tbody[{i}]//i[@class='remove icon']"));
                    specificDeleteIcon.Click();
                }
            }

        }



    }
}
