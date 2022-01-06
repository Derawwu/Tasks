Feature: Usage of button "More"

Scenario: User use the search bar, after that click on button "More" and chooses appropriate options, after that pop-up with succsess message will be displayed

	Given user enters to search bar text "Blouse" and press search button
	And click on button More
	And user choose quantity='3', size='L', color=white
	When user click on button "Add to cart"
	Then PopUp with success message is displayed