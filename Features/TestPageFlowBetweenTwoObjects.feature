Feature: PassingObjects

User is able to view users in Project Details page

//@tag1

Scenario: User clicks a button on example.com after navigating from google.com
    Given the user is on the Google homepage
    When the user searches for "https://www.globalsqa.com/samplepagetest/" and navigates to the website
    Then the user clicks the button on the page
