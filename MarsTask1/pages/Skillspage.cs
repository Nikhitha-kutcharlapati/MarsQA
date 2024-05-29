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
    public class Skillspage : CommonDriver
    {
        public Skillspage(IWebDriver driver) : base(driver)
        {

        }
        public Skillspage()
        {

        }
        // defining webelements ***************************
        public IWebElement usernameTextbox => driver.FindElement(By.XPath("//input[contains(@placeholder,'Email address')]"));
        public IWebElement passwordTextbox => driver.FindElement(By.XPath("//input[contains(@type,'password')]"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
        public IWebElement SkillsTab => driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
        public IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        public IWebElement addSkillTextbox => driver.FindElement(By.XPath("//*[@placeholder='Add Skill']"));
        public IWebElement chooseleveldropdown => driver.FindElement(By.XPath("//*[@class='ui fluid dropdown']"));
        public IWebElement chooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + Level + \"']"));
        public IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        public IWebElement ToolTipMessage => driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public IWebElement EditSkillsTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public IWebElement EditChooseLevelDropdown => driver.FindElement(By.XPath("//*[@class='ui fluid dropdown']"));
        public IWebElement EditPencilIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[4]/tr/td[3]/span[1]/i"));
        public IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement EditChooseLevelOption => driver.FindElement(By.XPath("//*[@value='\" + newLevel + \"']"));
        public IWebElement LastDeleteIcon => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[2]"));
        public IList<IWebElement> SkillsRows => driver.FindElements(By.XPath("//div[@data-tab='second']//table/tbody"));

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
        public void navigatetoSkill(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            SkillsTab.Click();
            Thread.Sleep(3000);
        }
        public void addSkillAction(IWebDriver driver, String skill, String level)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Click on add new button
            addNewButton.Click();
            // identify add skill textbox and add skill
            addSkillTextbox.SendKeys(skill);
            //Identify and select the skill level
            SelectElement select = new SelectElement(chooseleveldropdown);
            select.SelectByValue(level);

        }
        public void addSkill(IWebDriver driver)
        {

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Now add the language in the list

            Actions actions = new Actions(driver);
            actions.MoveToElement(addButton).Click().Perform();
          
        }
        public void EditSkillRecord(string oldSkill, string newSkill, string oldLevel, string newLevel)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Profile");
            Thread.Sleep(3000);

            // driver.Navigate().Refresh();
            SkillsTab.Click();
            Thread.Sleep(5000);
           

            // click edit pencil icon for the existing record
            // WaitUtils.WaitToBeVisible(driver, "Xpath", "EditPencilIcon", 5);
            //EditPencilIcon.Click();

            if (newSkill.Length > 0)
            {
                for (int i = 1; i <= SkillsRows.Count; i++)
                {
                    String getSkillName = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i}]/tr/td[1]")).Text;

                    Console.WriteLine(" ***************************************************" + getSkillName);

                    if (getSkillName == oldSkill)
                    {

                        IWebElement specificUpdateIcon = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i}]/tr/td[3]/span[1]/i"));

                        
                        specificUpdateIcon.Click();
                        EditSkillsTextbox.Clear();
                        EditSkillsTextbox.SendKeys(newSkill);


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
        

        //To Delete specific Language records
        public void DeletespecificSkillRecords(string newSkill)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Profile");
            Thread.Sleep(3000);

             driver.Navigate().Refresh();
           SkillsTab.Click();
            Thread.Sleep(5000);

          

           for (int i = 1; i <= SkillsRows.Count; i++)
            {
                String getSkillName = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i}]/tr/td[1]")).Text;
             


                if (getSkillName == newSkill)
                {
                    IWebElement specificDeleteIcon = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i}]/tr/td[3]/span[2]/i"));
                    
                    specificDeleteIcon.Click();
                }
            }

        }


    }
}