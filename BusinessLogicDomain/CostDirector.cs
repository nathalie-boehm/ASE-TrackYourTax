using System.Linq;
using TrackYourTax.DataObjects;

namespace TrackYourTax.BusinessLogicDomain
{
    public class CostDirector
    {
        private readonly IRepository _repository;
        private readonly ICostCalculator _costCalculator;

        public CostDirector(IRepository repository, ICostCalculator costCalculator)
        {
            _repository = repository;
            _costCalculator = costCalculator;
        }

        public int GetTotalCosts()
        {
            return _repository.Rides.Select(ride => _costCalculator.CalculateCost((Ride)ride)).Sum() +
                   _repository.Expenses.Select(expenses => _costCalculator.CalculateCost(expenses)).Sum();
        }
    }
}