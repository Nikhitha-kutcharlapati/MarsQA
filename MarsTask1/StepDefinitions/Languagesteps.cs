using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsTask1.Utilities;
using OpenQA.Selenium.Chrome;
using MarsTask1.pages;
using OpenQA.Selenium;
using System.Diagnostics;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsTask1.Hooks;
using System.Reflection.Emit;

namespace MarsTask1.StepDefinitions
{
    [Binding]
    public class Languagesteps
    {

        
        private Languagespage langobj;
        private readonly IWebDriver driver;
        public Languagesteps(IWebDriver driver)
        {
            langobj = new Languagespage(driver);
           
            this.driver = driver;
        }


        //*********************Language**********************
        [Given(@"user login to mars profile")]
        public void GivenUserLoginToMarsProfile()
        {
            langobj.launchProfile(driver);
            langobj.userLogin(driver);
        }
        [When(@"user navigates to languages and creates new language with '([^']*)' '([^']*)'")]
        public void WhenUserNavigatesToLanguagesAndCreatesNewLanguageWith(String language, String level)
        {
            langobj.addlanguageAction(driver, language, level);
        }

        [When(@"user add the language to profile")]
        public void WhenUserAddTheLanguageToProfile()
        {
            langobj.addLanguage(driver);
        }

        [Then(@"the tooltip message should be ""([^""]*)""")]
        public void ThenTheTooltipMessageShouldBe(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(langobj, expectedMessage);
        }

        // ******************* inserting NULL values **********************************//
       [Given(@"User log into the MARS portal")]
        public void GivenUserLogIntoTheMARSPortal()
        {
            langobj.launchProfile(driver);
            langobj.userLogin(driver);
        }


        [When(@"User create a new language record with NULL data '([^']*)' '([^']*)'")]
        public void WhenUserCreateANewLanguageRecordWithNULLData(String language, String level)
        {
            langobj.addlanguageAction(driver, language, level);
            langobj.addLanguage(driver);
        }
        
        [Then(@"the tooltip message should ""([^""]*)""")]
        public void ThenTheTooltipMessageShould(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(langobj, expectedMessage);
        }
       


        //Inserting DUPLICATE VALUES **************************************

        [Given(@"User log into MARS")]
        public void GivenUserLogIntoMARS()
        {
            langobj.launchProfile(driver);
            langobj.userLogin(driver);
        }

        
                [When(@"User create a new language record <language> '([^']*)'")]
                public void WhenUserCreateANewLanguageRecordLanguage(string language, string level)
                {
                    langobj.addlanguageAction(driver, language, level);
                    langobj.addLanguage(driver);
                }

                
        

        [When(@"User edit an existing Language record '([^']*)'  '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditAnExistingLanguageRecord(string oldLanguage, string newLanguage, string oldLevel, string newLevel)
        {
           
            langobj.EditLanguageRecord(oldLanguage, newLanguage, oldLevel, newLevel);

        }
        [Then(@"the tooltip message should display this ""([^""]*)""")]
        public void ThenTheTooltipMessageShouldDisplayThis(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(langobj, expectedMessage);
        }

        [Then(@"the tooltip message should be given as""([^""]*)""")]
        public void ThenTheTooltipMessageShouldBeGivenAs(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(langobj, expectedMessage);
        }


        [When(@"User delete an existing Language record '([^']*)'")]
        public void WhenUserDeleteAnExistingLanguageRecord(string newLanguage)
        {
            
            langobj.DeletespecificLanguageRecords(newLanguage);
        }

        
        [Then(@"the tooltip message should be dispalyed as ""([^""]*)""")]
        public void ThenTheTooltipMessageShouldBeDispalyedAs(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(langobj, expectedMessage);
        }




    }
}



