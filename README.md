# Proof of concept of integration of Playwright with SpecFlow and NUnit

This project is a generic test or proof of concept for the integration of Playwright, C#, SpecFlow, and NUnit libraries into one working test framework.
Overview

The project includes several features, hooks, page objects, steps, and utils. It uses the Page Object Model design pattern to create a clean and maintainable codebase.
# Project Structure

The project is structured as follows:

```(bash)
Solution
├── Auth
|   └── auth.json
├── Component
|   └── MuiDataGrid.cs
├── Config
|   └── AppConfig.cs
├── DI
|   ├── ContainerConfig.cs
├── Drivers
|   ├── Driver.cs
|   ├── DriverFactory.cs
|   ├── IDriverFactory.cs
|   ├── IPageFactory.cs
|   ├── PageFactory.cs
|   └── PlaywrightDriverFactory.cs
├── Features
|   ├── Feature1.feature
|   └── Feature2.feature
├── Hooks
|   └── Hook.cs
├── PageObjects
|   ├── BasePage.cs
|   ├── GooglePage.cs
|   └── SampleTestPage.cs
├── Steps
|   └── TestPageFlowBetweenTwoObjects.cs
└── Utils
    ├── EmailHelper.cs
    ├── NamesDictionary.cs
    └── RandomStringsHelpers.cs
```
# Usage

To use this project, follow these steps:

    Clone the repository.
    Open the solution file in Visual Studio.
    Build the solution.
    Run the tests.

# Contributing

Contributions are welcome! Please submit a pull request to the develop branch.
# License

This project is licensed under the MIT License. See the LICENSE file for details.

# Introduction of API connector point
Integration of API testing can help create more comprehensive end-to-end tests that cover both the user interface and the underlying APIs. This can give more complete picture of your application's functionality and performance and help identify potential issues that may not be visible through UI testing alone.
Example of gherking based api scenario
```(bash)
Given the API endpoint for getting a list of users is available
When I make a GET request to the API endpoint
Then the API should return a list of users
And each user in the list should have a name, email, and ID field
```
By using BDD and Gherkin syntax, the API tests can be easily understood by all stakeholders and ensure that the system behaves as expected.
