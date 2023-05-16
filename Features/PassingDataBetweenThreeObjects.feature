Feature: PassingDataBetweenThreeObjects

A short summary of the feature

@tag1
Scenario: User clicks a button on example.com after navigating from google.com then nabigates to another page
    Given the user is on the Google homepage
    When the user searches for "https://www.globalsqa.com/samplepagetest/" and navigates to the website
    Then the user clicks the button on the page
    And the user clicks different tabs

