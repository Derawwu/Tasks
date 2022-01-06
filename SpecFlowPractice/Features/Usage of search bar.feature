Feature: Usage of search bar

Scenario:  User enters search request and opened page has the same h1 text as search request

Given User enters to search bar text 'summer' and press button enter
Then h1 text is '"SUMMER"'

