using MarsTask1.pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsTask1.Utilities;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MarsTask1.Hooks;
using System.Reflection.Emit;

namespace MarsTask1.StepDefinitions
{
    [Binding]
    public class Skillssteps
    {


        private Skillspage skillObj;
        private readonly IWebDriver driver;
        public Skillssteps(IWebDriver driver)
        {
            skillObj = new Skillspage(driver);

            this.driver = driver;
        }
        //Defining the Steps 


        [Given(@"user login to mars profile using Username and password")]
        public void GivenUserLoginToMarsProfileUsingUsernameAndPassword()
        {
            skillObj.launchProfile(driver);
            skillObj.userLogin(driver);
        }

        [When(@"user navigates to Skills and creates new Skill with '([^']*)' '([^']*)'")]
        public void WhenUserNavigatesToSkillsAndCreatesNewSkillWith(string skill, string level)
        {

            skillObj.navigatetoSkill(driver);
            skillObj.addSkillAction(driver, skill, level);
        }

        [When(@"user add the skill to profile")]
        public void WhenUserAddTheSkillToProfile()
        {
            skillObj.addSkill(driver);
        }

        [Then(@"the tooltip message is ""([^""]*)""")]
        public void ThenTheTooltipMessageIs(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(skillObj, expectedMessage);
        }

        [When(@"User Navigates to Skills")]
        public void WhenUserNavigatesToSkills()
        {
            skillObj.navigatetoSkill(driver);
        }

        [When(@"User create a new skill record with NULL data '([^']*)' '([^']*)'")]
        public void WhenUserCreateANewSkillRecordWithNULLData(string skill, string level)
        {
            skillObj.addSkillAction(driver, skill, level);
            skillObj.addSkill(driver);
        }

        [Then(@"the tooltip message should be  ""([^""]*)""")]
        public void ThenTheTooltipMessageShouldBe(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(skillObj, expectedMessage);
        }

        [When(@"User create a new skill record with NULL data value '([^']*)' '([^']*)'")]
        public void WhenUserCreateANewSkillRecordWithNULLDataValue(string skill, string level)
        {
            skillObj.addSkillAction(driver, skill, level);
            skillObj.addSkill(driver);
        }

        [Then(@"tooltip message should be ""([^""]*)""")]
        public void ThenTooltipMessageShouldBe(string expectedMessage)
        {
            AssertionHelpers.AssertToolTipMessage(skillObj, expectedMessage);
        }

        [When(@"User edit an existing skill record '([^']*)'  '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditAnExistingSkillRecord(string oldskill, string newskill, string oldLevel, string newLevel)
        {
        
            skillObj.EditSkillRecord(oldskill, newskill, oldLevel, newLevel);
        }

        [When(@"User delete an existing skill record '([^']*)'")]
        public void WhenUserDeleteAnExistingSkillRecord(string skill)
        {
            skillObj.navigatetoSkill(driver);
            skillObj.DeletespecificSkillRecords(skill);
        }



    }
}
