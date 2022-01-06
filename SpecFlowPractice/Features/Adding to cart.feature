Feature: Adding goods to the cart
	Simple calculator for adding two numbers

Scenario: add product to the cart
	Given User enters to search bar text 'summer' and press button enter, after that filter 'price:desc' choosed 
	When User adds product to the cart and opens cart
	Then Price of product in the cart must be same as price at the product list

