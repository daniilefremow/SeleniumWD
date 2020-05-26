Feature: Product addition
		As a user 
		I want to open the application
		So I can add a product

		Scenario: Product creation

		Given I open "http://localhost:5000" url
		When I enter the Name - "user" and the Password - "user"
		And I click on the login confirmation button
		And I open All Products page
		And I click on the Add product button
		And I enter the Product Name - "Sweets"
		And I choose the Category - "Condiments"
		And I choose the Supplier - "Norske Meierier"
		And I enter the Unit Price - "90"
		And I enter the Quantity per Unit - "3"
		And I enter the Units in Stock - "120"
		And I enter the Units on Order - "40"
		And I enter the Reorder Level - "5"
		And I click on the Add product confirmation button
		Then The product "Sweets" should be presented