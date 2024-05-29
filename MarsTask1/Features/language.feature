Feature: This feature contains test scenarios for Language feature
	create, edit and delete operations

Scenario Outline: a. Add - Verify user is able to add new Language
Given user login to mars profile
When user navigates to languages and creates new language with <Language> <Level>
And user add the language to profile
Then the tooltip message should be "<Language> has been added to your languages"

Examples:
 | Language    | Level               |
 | 'English'   | 'Basic'             |
 | 'Telugu'    | 'Native/Bilingual'  |

 Scenario Outline: b. Create a language record with NULL data
	Given User log into the MARS portal 
	When User create a new language record with NULL data <Language> <Level>
	Then the tooltip message should "Please enter language and level"

Examples:
	 | Language    | Level               |
	 | ''          | 'Basic'             |

 Scenario Outline: c. Create a language record with duplicate data
	Given User log into MARS
	When User create a new language record with NULL data <Language> <Level>
	Then the tooltip message should display this "This language is already exist in your language list." 

Examples:
 | Language    | Level               |
 | 'English'   | 'Basic'             |

 Scenario Outline: d. Edit an existing Language record
    Given User log into the MARS portal 
    When User edit an existing Language record <oldLanguage>  <newLanguage> <oldLevel> <newLevel>
    Then the tooltip message should be given as"<newLanguage> has been updated to your languages"

    Examples:
      | oldLanguage | newLanguage | oldLevel           | newLevel         |
      | 'English'   | 'Spanish'   | 'Basic'            | 'Conversational' |
     
      

 Scenario Outline: e. Delete an existing Language record
    Given User log into the MARS portal 
    When User delete an existing Language record <newLanguage>
    Then the tooltip message should be dispalyed as "<newLanguage> has been deleted from your languages"

    Examples: 
        | newLanguage |
        | 'Spanish'   |
        | 'Telugu'    |
           
     





