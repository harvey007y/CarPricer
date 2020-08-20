# CarPricer
C# Console with unit tests for car pricing

Instructions
 
  You are tasked with writing an algorithm that determines the value of a used car, 
  given several factors.
 
     AGE:    Given the number of months of how old the car is, reduce its value one-half 
             (0.5) percent.
             After 10 years, it's value cannot be reduced further by age. This is not 
             cumulative.
             
     MILES:    For every 1,000 miles on the car, reduce its value by one-fifth of a
               percent (0.2). Do not consider remaining miles. After 150,000 miles, it's 
               value cannot be reduced further by miles.
             
     PREVIOUS OWNER:    If the car has had more than 2 previous owners, reduce its value 
                        by twenty-five (25) percent. If the car has had no previous  
                        owners, add ten (10) percent of the FINAL car value at the end.
                     
     COLLISION:        For every reported collision the car has been in, remove two (2) 
                       percent of it's value up to five (5) collisions.
 
     RELIABILITY:      If the Make is Toyota, add 5%.  If the Make is Ford, subtract $500.
 
 
     PROFITABILITY:    The final calculated price cannot exceed 90% of the purchase price. 
     
  
     Each factor should be off of the result of the previous value in the order of
         1. AGE
         2. MILES
         3. PREVIOUS OWNER
         4. COLLISION
         5. RELIABILITY
         
     E.g., Start with the current value of the car, then adjust for age, take that  
     result then adjust for miles, then collision, previous owner, and finally reliability. 
     Note that if previous owner, had a positive effect, then it should be applied 
     AFTER step 5. If a negative effect, then BEFORE step 5.
