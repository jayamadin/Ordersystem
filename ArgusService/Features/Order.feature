  Feature: Testing the restaurant checkout system
        
  Scenario:A correct bill for a group of 4 orders is Returned correctly
    Given A group of 4 people place an order at 15.00
    And The order contains 1 starter 1 drinks 1 main per person 
    When The bill is requested
    Then The correct amount of 55.4 is Returned
      
  Scenario:A correct bill for a group of 2 placed orders made before 7pm is Returned correctly
    Given A group of 2 people place an order at 15.00
    And The order contains 1 starter 1 drinks 1 main per person 
    And The bill is requested
    And The correct amount of 27.7 is Returned
    When A group of 2 people place an order at 20.00
    And The order contains 0 starter 1 drinks 1 main per person
    And The bill is requested
    Then The correct amount of 48.1 is Returned
    
    
  
  Scenario: A correcrt bill is calculated after an order is removed
    Given A group of 4 people place an order at 15.00
    And The order contains 1 starter 1 drinks 1 main per person
    And The bill is requested
    And The correct amount of 55.4 is Returned
    When An order is removed from the bill
    And The bill is requested
    Then The correct amount of 41.6 is Returned