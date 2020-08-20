using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPricer
{
    public class PriceDeterminator
    {
        public decimal DetermineCarPrice(Car car)
        {

            //*AGE:    Given the number of months of how old the car is, reduce its value one-half
            //* (0.5) percent. After 10 years, it's value cannot be reduced further by age. This is not 
            //* cumulative.
             int age = 0;
            double ageFactor = 0;
            if (car.AgeInMonths > 120)
            {
                age = 120;
            } else
            {
                age = car.AgeInMonths;
            }
            ageFactor = age * -.005;

            //  MILES:    For every 1,000 miles on the car, reduce its value by one-fifth of a
            // *percent(0.2).Do not consider remaining miles. After 150,000 miles, it's 
            //* value cannot be reduced further by miles.
            int miles = 0;
            double milesFactor = 0;
            if (car.NumberOfMiles > 150000)
            {
                miles = 150000;
            }
            else
            {
                miles = car.NumberOfMiles;
            }
            milesFactor = miles / 1000 * -.002;

            // *PREVIOUS OWNER: If the car has had more than 2 previous owners, reduce its value
            // *by twenty - five(25) percent.If the car has had no previous
            //* owners, add ten(10) percent of the FINAL car value at the end.

            int previousOwner = 0;
            double previousOwnerFactor = 0;
            if (car.NumberOfPreviousOwners > 2)
            {
                previousOwnerFactor = -.25;
            }
            if (car.NumberOfPreviousOwners == 0)
            {
                previousOwnerFactor = .10;
            }

            // *COLLISION:        For every reported collision the car has been in,
            // remove two(2) percent of it's value up to five (5) collisions.
            int collision = 0;
            double collisionFactor = 0;
            if (car.NumberOfCollisions > 5)
            {
                collision = 5;
            } else
            {
                collision = car.NumberOfCollisions;
            }
            collisionFactor = collision * -.02;

            //RELIABILITY: If the Make is Toyota, add 5 %.If the Make is Ford, subtract $500.
            double reliabilityFactorFixedAmt = 0;
            double reliabilityFactorPercent = 0;

            if (car.Make != null)
            {
                if (car.Make.ToLower() == "toyota")
                {
                    reliabilityFactorPercent = .05;
                }

                if (car.Make.ToLower() == "ford")
                {
                    reliabilityFactorFixedAmt = -500;
                }
            }

            //*PROFITABILITY:    The final calculated price cannot exceed 90 % of the purchase price.
            double profitabilityFactor = (double)car.PurchaseValue * .9;

            // *Each factor should be off of the result of the previous value in the order of
            //* 1.AGE
            //* 2.MILES
            //* 3.PREVIOUS OWNER
            //* 4.COLLISION
            //* 5.RELIABILITY
            //*
            //*E.g., Start with the current value of the car, then adjust for age, take that
            //* result then adjust for miles, then collision, previous owner, and finally reliability.

            //* Note that if previous owner, had a positive effect, then it should be applied
            //*AFTER step 5.If a negative effect, then BEFORE step 5.
            double newValue = (double)car.PurchaseValue;
            newValue += (newValue * ageFactor);
            newValue += newValue * milesFactor;
            if (previousOwnerFactor < 0)
            {
                newValue += newValue * previousOwnerFactor;
            }
            newValue += newValue * collisionFactor;
            newValue += newValue * reliabilityFactorPercent + reliabilityFactorFixedAmt;
            if (previousOwnerFactor > 0)
            {
                newValue += newValue * previousOwnerFactor;
            }

            if (newValue > profitabilityFactor)
            {
                newValue = profitabilityFactor;
            }

            return (decimal)newValue;
        }
    }
}
