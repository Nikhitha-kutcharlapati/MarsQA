Feature: This feature contains test scenarios for Skill feature
	create, edit and delete operations

Scenario Outline: a. Add - Verify user is able to add new Skill
Given user login to mars profile using Username and password
When user navigates to Skills and creates new Skill with <Skill> <Level>
And user add the skill to profile
Then the tooltip message is "<Skill> has been added to your skills"


Examples:
      | Skill       | Level            |
      | 'SpecFlow'  | 'Beginner'       |
      | 'GitHub'    | 'Intermediate'   |
     

 Scenario Outline: b. Create a skill record with NULL data
	Given user login to mars profile using Username and password
	When User Navigates to Skills
    And User create a new skill record with NULL data value <Skill> <Level>
	Then the tooltip message should be  "Please enter skill and experience level"

Examples:
   	  | Skill       | Level            |
      | ''          | 'Beginner'       |
     

 Scenario Outline: c. Create a skill record with duplicate data
	Given user login to mars profile using Username and password
    When User Navigates to Skills
	And User create a new skill record with NULL data value <Skill> <Level>
	Then tooltip message should be "This skill is already exist in your skill list."  

Examples:
      | Skill       | Level            |
      | 'SpecFlow'  | 'Beginner'       |

 Scenario Outline: d. Edit an existing skill record
  Given user login to mars profile using Username and password 
    When User Navigates to Skills
    And User edit an existing skill record <oldSkill>  <newSkill> <oldLevel> <newLevel>
    Then tooltip message should be "<newSkill> has been updated to your skills"

    Examples:
       | oldSkill    | newSkill    | oldLevel        | newLevel       |
       | 'SpecFlow'  | 'Cucumber'  |  'Beginner'     | 'Intermediate' |
     
      

 Scenario Outline: e. Delete an existing skill record
   Given user login to mars profile using Username and password
    When User delete an existing skill record <Skill>
    Then tooltip message should be "<Skill> has been deleted"

    Examples: 
        |   Skill     |
        | 'Cucumber'  | 
        | 'GitHub'    |
        
           
     





