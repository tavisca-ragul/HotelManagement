Feature: Hotel Management
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| description           | id | name        |
| Add_hotel_Nala        | 1  | Nala        |
| Add_hotel_Le-Meridian | 2  | Le-Meridian |
| Add_hotel_Hyatt       | 3  | Hyatt       |

@GetHotel
Scenario Outline: User gets hotel from database by providing valid id
    Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	And User called AddHotel api
    When User calls GethotelById api '<id>'
    Then Hotel with name '<name>' which got by id should be present in the response
Examples: 
| description | id | name        |
| Get_id_1    | 4  | Nala        |
| Get_id_2    | 5  | Le-Meridian |
| Get_id_3    | 6  | Hyatt       |

@GetAllHotels
Scenario Outline: User gets list of all the hotels added
	Given User provided valid Id '<id1>'  and '<name1>'for hotel 
	And User has added required details for hotel
	And User called AddHotel api
	And User provided valid Id '<id2>'  and '<name2>'for hotel 
	And User has added required details for hotel
	And User called AddHotel api
	And User provided valid Id '<id3>'  and '<name3>'for hotel 
	And User has added required details for hotel
	And User called AddHotel api
	When User calls GetAllHotels api
	Then Hotel with names '<name1>,<name2>,<name3>' should be present in the response
Examples: 
| description                             | id1  | name1       | id2  | name2       | id3  | name3  |
| Get_hotels_nala_Anjali_Hemala           | 7    | Nala        | 8    | Anjali      | 9    | Hemala |
| Get_hotels_Blackpearl_Le-Meridian_ IBIS | 10   | Blackpearl  | 11   | Le-Meridian | 12   | IBIS   |
| Get_hotels_GreenTower_Residency_Hyatt   | 13   | Green Tower | 14   | Residency   | 15   | Hyatt  |
