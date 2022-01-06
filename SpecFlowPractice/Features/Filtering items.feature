Feature: Filtering items

Scenario: Usage of filters dropdown

Given User enters to search bar text 'summer' and press button enter , click on dropdown with filtering option
When choosed option from high to low price
Then appropriate layout of items should be displayed