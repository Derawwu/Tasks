Feature: Deleting items from cart

Scenario: delete one of two items from cart and verify that in cart repsesented only one item, which wasn't deleted
	Given User enters to search bar text "Blouse" and click on search button
	And User clicks on button more for the first found product
	And user choose quantity="3", size="L", color = white
	And user click on the button "Add to cart"
	And user click on button "Continue shopping" in the opened popup
	And User enters to search bar text "Printed summer dress" and click on search button another one time
	And User clicks on the button more for first found product another one time
	And user choose quantity="5", size="M", color = orange another one time
	And user click on the button "Add to cart" another one time
	And user click on the button "Proceed to checkout" in opened popup
	When user click on item's trashbin button 
	Then product removed from the cart

	