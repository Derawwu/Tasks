Feature: Adding goods to the cart
	Simple calculator for adding two numbers

Scenario: Add product to the cart
	Given the user entered to search bar text 'summer' and pressed button enter, after that filtering for expensive first had been chosen
	When the user adds product to the cart and opens cart
	Then the price of product in the cart must be same as price at the product list

