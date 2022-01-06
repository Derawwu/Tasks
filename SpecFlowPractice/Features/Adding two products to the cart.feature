Feature: Adding two products to the cart


Scenario Outline: Adding two products to the cart with usage of button More
	Given User enters to search bar text "<searchRequest1>" and click on the search button
	And User clicks on button more for first found product
	And user choose quantity="<quantity1>", size="<size1>", color=white
	And user click on button "Add to cart"
	And user click on button "Continue shopping" in opened popup
	And User enters to search bar text "<searchRequest2>" and click on search button another one time
	And User clicks on button more for first found product another one time
	And user choose quantity="<quantity2>", size="<size2>", color=orange another one time
	And user click on button "Add to cart" another one time
	When user click on button "Proceed to checkout" in opened popup
	Then In cart shown previously choosed options for both of products
	
	Examples: 
	| searchRequest1 | quantity1 | size1 | searchRequest2       | quantity2 | size2 |
	| Blouse         | 3         | L     | Printed summer dress | 5         | M     |
	




