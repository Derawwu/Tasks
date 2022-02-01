Feature: 1.Get querry from CUSTOMERS table

Scenario: 1.1. Get list of customers and assert that it has count equal to 5
When system perform get customer querry
Then count of customers must be equal to 5

Scenario: 1.2. Get list of customers and assert that its first member is "Global Logic"
When the system perform get customer querry
Then first member must be "Global Logic"

Scenario: 1.3. Get list of customers and assert that there are not present duplicates in the list
When the system perform get all customer querry
Then count of all customers must be equal to the count of distinct users

Scenario: 1.4. Get list of customers and assert that it isn't equals null
When system perform get all customer querry
Then responce must not be null