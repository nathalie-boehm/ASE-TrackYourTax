using TrackYourTax.DataObjects;

namespace TrackYourTax.BusinessLogicDomain
{
    public interface ICostCalculator
    {
        int CalculateCost(Ride ride);
        int CalculateCost(Expenses ride);
        int ElstarCosts(Ride ride);
        int AdditionalCateringExpenses(Ride ride);
    }
}