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

        public int CalculateCost(Ride ride)
        {
            var route = ride.Route;
            if (route == null) return 0;

            var result = (int)(ride.AttendanceCounter * route.Distance * GetRideFactor(route.Destination.LocationCategory) * _settings.KilometerPrice / 100);

            if (result > 0 && AdditionalCateringExpenses(ride))
            {
                return result + _settings.CateringAdditionalExpenses;
            }

            return result;
        }

        private bool AdditionalCateringExpenses(Ride ride) => ride.Route.Destination.LocationCategory == LocationCategory.ZweiteTaetigkeitsstaette &&
                ride.End.Subtract(ride.Start).TotalHours >= 8;

        public int CalculateCost(Expenses expenses)
        {
            return (int)GetExpensesFactor(expenses.Category) * expenses.Amount;
        }
    }
}