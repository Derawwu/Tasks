Feature: 2.Adding goods to the cart

Scenario: 2.1 Add product to the cart
	Given the user entered to search bar text 'summer' and pressed button enter, after that filtering for expensive first had been chosen
	When the user adds product to the cart 
	Then user opens cart and the price of product in the cart must be same as price at the product list

