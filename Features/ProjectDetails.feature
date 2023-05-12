Feature: ProjectDetails

User is able to view users in Project Details page

//@tag1
Background:
    Given I am logged into SSP
    And I am have opened an existing project
   
Scenario Outline: User is able to select a project in their my projects page to view the details of the users

Given I am on project details page //Project Details
When I click on a USERS tab
And I click on Collapse All button
Then the details of all users in the project are visible
And the following <columns> are showing the details

    Examples:
    | columns |
    | Name    |
    | Email   |
    | Role    |
    | Tools   |
    


Scenario Outline: There can be only one Product Owner on the page
  
Given My projects page is displayed 
When the project has too many PO's
Then a warning page is visible
