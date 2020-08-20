using NUnit.Framework;
namespace CarPricer { 

[TestFixture]
public class UnitTests
{

    [Test]
    public void CalculateCarValue()
    {
        AssertCarValue(24813.40m, 35000m, 3 * 12, 50000, 1, 1, "Ford");
        AssertCarValue(20672.61m, 35000m, 3 * 12, 150000, 1, 1, "Toyota");
        AssertCarValue(19688.20m, 35000m, 3 * 12, 250000, 1, 1, "Tesla");
        AssertCarValue(21094.5m, 35000m, 3 * 12, 250000, 1, 0, "toyota");
        AssertCarValue(21657.02m, 35000m, 3 * 12, 250000, 0, 1, "Acura");
        AssertCarValue(72000m, 80000m, 8, 10000, 0, 1, null);
    }

    private static void AssertCarValue(decimal expectValue, decimal purchaseValue,
    int ageInMonths, int numberOfMiles, int numberOfPreviousOwners, int
    numberOfCollisions, string make)
    {
        Car car = new Car
        {
            AgeInMonths = ageInMonths,
            NumberOfCollisions = numberOfCollisions,
            NumberOfMiles = numberOfMiles,
            NumberOfPreviousOwners = numberOfPreviousOwners,
            PurchaseValue = purchaseValue,
            Make = make
        };
        PriceDeterminator priceDeterminator = new PriceDeterminator();
        var carPrice = priceDeterminator.DetermineCarPrice(car);
        Assert.AreEqual(expectValue, carPrice);
    }
        }
}