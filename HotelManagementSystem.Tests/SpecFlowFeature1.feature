Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with Id '<id>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario: User added a hotel and get it using id
	Given User added a new hotel with id 4 and name hotel4
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls GetHotelById 4 api
	Then Hotel with id 4 should be present
	
Scenario Outline: User added multiple hotels and get them
	Given User provided valid Id '<id>'  and '<name>'for hotel
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls Get All Hotels
	Then All Hotels should be present
Examples: 
| id | name   |
| 5  | hotel5 |
| 6  | hotel6 |
| 7  | hotel7 |
| 8  | hotel8 |
| 9  | hotel9 |