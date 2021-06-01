using System.Linq;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.BusinessLogicDomain
{
    public abstract class CostCalculatorBase : ICostCalculator
    {
        private readonly Settings _settings;

        protected CostCalculatorBase(IRepository repository)
        {
            _settings = repository.GetCurrentSetting();
        }
        protected abstract decimal GetRideFactor(LocationCategory category);
        protected abstract decimal GetExpensesFactor(ExpensesCategory category);

        public int CalculateCost(Ride ride) =>
            (int)(ElstarCosts(ride) * GetRideFactor(ride.Route.Destination.LocationCategory)) +
            AdditionalCateringExpenses(ride);

        public int ElstarCosts(Ride ride)
        {
            var route = ride.Route;
            if (route == null) return 0;
            return (int)(ride.AttendanceCounter * route.Distance * _settings.KilometerPrice / 100);
        }

        public int AdditionalCateringExpenses(Ride ride)
            => ride.Route.Destination.LocationCategory == LocationCategory.ZweiteTaetigkeitsstaette &&
               ride.End.Subtract(ride.Start).TotalHours >= 8 && ElstarCosts(ride) > 0 ? _settings.CateringAdditionalExpenses : 0;

        public int CalculateCost(Expenses expenses)
        {
            return (int)GetExpensesFactor(expenses.Category) * expenses.Amount;
        }
    }
}